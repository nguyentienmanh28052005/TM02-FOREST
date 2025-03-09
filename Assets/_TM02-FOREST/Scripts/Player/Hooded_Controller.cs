using System.Collections;
using UnityEngine;


public class Hooded_Controller : Subject
{
    private float _speed = 0;
    private Rigidbody2D _rb;
    private Animator _anim;
    private float _horizontalInput;
    private bool isfacingRight = true;
    private string _animID_speed;
    private DataSkill _skill;
    private bool isAttacking;
    
    [Header("Jump")]
    private bool doubleJump;
    public float jumpHeight = 0.23f;
    public bool onJump;
    public float gravityScale;
    public float fallGravityScale;
    [SerializeField] private Hooded_ParticleEffect _particleJump;
    public float timeParticleJump;
    
    [Header("Dash")]
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private Hooded_ParticleEffect _particleDash;
    public float timeParticleDash;
    
    [Header("GroundCheck")]
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    private InputManager _input;

    //[SerializeField] private GameObject AudioFootStep;
    private FootStepManage _footStep;
    
    //[SerializeField] private GameObject _frameBar;
    private EnegyBar _enegyBar;

    public bool isGrounds;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _skill = GetComponent<DataSkill>();
        _input = GetComponent<InputManager>();  
        //_footStep = AudioFootStep.GetComponent<FootStepManage>();
        //_enegyBar = _frameBar.GetComponent<EnegyBar>();
    }
    
    void Start()
    {
        _animID_speed = "Speed";
    }

    

    void Update()
    {
        isAttacking = _skill.GetIsAttacking();
        Jump();
        Fall();
        if(isDashing || isAttacking)
        {
            return;
        }
        UpdateSkill(1);
        Flip();
        if(Input.GetKeyDown(KeyCode.M) && canDash)
        {
                StartCoroutine(Dash());
        }
        isGrounds = isGrounded();
            
    }
    
    void FixedUpdate()
    {
        if(isDashing || isAttacking)
        {
            return;
        }
        Move();
    }

    public void UpdateSkill(int other)
    {
        if (other == 1)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                _skill.bulletFire1();
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                if (_enegyBar.GetCurrentEnegy() > 30f)
                {
                    _skill.bulletUltiFire();
                    _enegyBar.UpdateBar(-30f);
                }
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                _skill.skillWaterBall();
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                _skill.BaseSkill();
            }
        }
        else if (other == 2)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                StartCoroutine(_skill.Skill1Has());
            }
        }
    }
    

    public bool GetDirection()
    {
        return isfacingRight;
    }
    
    void Move()
    {
        _speed = 4f;
        _anim.SetFloat(_animID_speed, 0f);
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        if (_horizontalInput == 0 || !isGrounded())
        {
            //_footStep.OffAudio();
        }
        if (_horizontalInput != 0)
        {
            //if(isGrounded()) _footStep.OnAudioRun();
            _speed = 7f;
            _anim.SetFloat(_animID_speed, _speed);
        }
        if (Input.GetKey(KeyCode.LeftShift) && _horizontalInput != 0)
        {
           //if(isGrounded())  _footStep.OnAudioWalk();
            _speed = 3.5f;
            _anim.SetFloat(_animID_speed, _speed);
        }
        _rb.velocity = new Vector2(_horizontalInput, _rb.velocity.y);
        Debug.Log(_horizontalInput);
        transform.Translate(_rb.velocity * Time.deltaTime * _speed);
    }

     void Jump()
    {
        if(isGrounded() && !Input.GetKey(KeyCode.Space))
        {
            doubleJump = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded() || doubleJump)
            {
                if (doubleJump)
                {
                    _particleJump.PlayParticle(timeParticleJump);
                    jumpHeight = 0.5f;
                }
                else
                {
                    jumpHeight = 0.3f;
                }
                StopCoroutine(AnimJump());
                StartCoroutine(AnimJump());
                _rb.gravityScale = gravityScale;
                float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * _rb.gravityScale) * -2) * _rb.mass;
                _rb.velocity = new Vector2(0f, 0f);
                _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                doubleJump = !doubleJump;
            }
        }
        if(_rb.velocity.y > 0)
        {
            _rb.gravityScale = gravityScale;
        }
        else
        {
            _rb.gravityScale = fallGravityScale;
        }

        if (_rb.velocity.y < -2f) _rb.velocity = new Vector2(_rb.velocity.x, -2f);
    }

    
    private void Fall()
    {
        if(!isGrounded() && !onJump) _anim.SetBool("Fall", true);
        if(isGrounded() || _rb.velocity.y > 0 || _skill.GetIsAttacking()) _anim.SetBool("Fall", false);
    }
 
    private IEnumerator AnimJump()
    {
        onJump = true;
        _anim.SetBool("Jump", true);
        yield return new WaitForSeconds(0.5f);
        onJump = false;
        _anim.SetBool("Jump", false);
    }
    
    public bool GetStatusJump()
    {
        return doubleJump;
    }
    
    private void Flip()
    {
        if(isfacingRight && _horizontalInput < 0 || !isfacingRight && _horizontalInput > 0){
            if(_skill.GetStatusSkillBase1() == true) _skill.SetSkillBase1False();
            if(_skill.GetStatusSkillBase2() == true) _skill.SetSkillBase2False();
            isfacingRight = !isfacingRight;
            Vector3 kich_thuoc = transform.localScale;
            kich_thuoc.x = -1 * kich_thuoc.x;
            transform.localScale = kich_thuoc;
        }
    }
    
    private IEnumerator Dash()
    {
        _particleJump.Stop();
        canDash = false;
        isDashing = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        _particleDash.PlayParticle(timeParticleDash);
        yield return new WaitForSeconds(dashingTime);
        _rb.gravityScale = originalGravity;
        isDashing = false;
        _rb.velocity = new Vector2(_rb.velocity.x,  0);
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }
    
    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer)){
            return true;
        }
        else 
        {
            return false;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }
    
}
