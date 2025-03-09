using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public class BossCrystal_Manager : Subject
{
    [SerializeField] private StateManager _stateManager;
    [SerializeField] private GameObject _player;
    private bool _isFacingRight = false;
    private Animator _anim;
    private int _horizontal = -1;
    public float _speed = 0f;
    private Rigidbody2D _rb;
    public static string _currentState;
    private bool _isAttack;
    
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    
    public float jumpHeight = 0.23f;
    public float gravityScale;
    public float fallGravityScale;
    public bool onJump = false;

    public bool isGround;
    
    public static bool _busy = false;
    
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;
    
    [SerializeField] private GameObject _attack1;
    [SerializeField] private CameraShake _cameraShake;
    
    [SerializeField] private GameObject _firePos;
    [SerializeField] GameObject _bullet;

    [Header("Zone")] 
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    
    
    public void Start()
    {
        _stateManager = GetComponent<StateManager>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        isGround = isGrounded();
        _anim.SetFloat("Speed", _speed);
        Fall();
    }
    
    public void InstanceBullet()
    {
        StartCoroutine( WaitInstanceBullet(0.3f));
    }
    
    public IEnumerator WaitInstanceBullet(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject bullet = Instantiate(_bullet, _firePos.transform.position, transform.rotation);
        bullet.transform.localScale = transform.localScale;
    }
    
    public void MoveForward()
    {
        if (_isFacingRight) _horizontal = 1;
        else _horizontal = -1;
        _rb.velocity = new Vector2(_horizontal, _rb.velocity.y);
        transform.Translate(_rb.velocity * Time.deltaTime * _speed);
    }
    
    public void LookAtObject(GameObject _object)
    {
        if (transform.position.x - _object.transform.position.x > 0)
        {
            if(_isFacingRight) Flip();
        }
        else 
            if(!_isFacingRight) Flip();
    }

    public void Flip()
    {
        Vector3 kich_thuoc = transform.localScale;
        kich_thuoc.x = -1 * kich_thuoc.x;
        transform.localScale = kich_thuoc;
        _isFacingRight = !_isFacingRight;
    }

    public IEnumerator Attack1()
    {
        _busy = true;
        Jump();
        yield return new WaitForSeconds(1.3f);
        _rb.velocity = new Vector2(0, 0);
        _anim.SetBool("Fall", false);
        _anim.SetTrigger("AttackAir");
        yield return new WaitForSeconds(0.3f);
        _rb.velocity = new Vector2(0, 0);
        _attack1.SetActive(true);
        _cameraShake.ShakeCamera(5f);
        yield return new WaitForSeconds(0.5f); 
        _attack1.SetActive(false);
        Flip();
        _anim.SetTrigger("AttackAir");
        yield return new WaitForSeconds(0.3f);
        _rb.velocity = new Vector2(0, 0);
        _attack1.SetActive(true);
        _cameraShake.ShakeCamera(5f);
        yield return new WaitForSeconds(0.5f); 
        _attack1.SetActive(false);
        LookAtObject(_player);
        yield return new WaitForSeconds(2f); 
        _busy = false;
    }

    public IEnumerator Attack2()
    {
        LookAtObject(_player);
        _busy = true;
        //StartCoroutine(Dash());
        _anim.SetTrigger("Attack4");
        yield return new WaitForSeconds(3f);
        LookAtObject(_player);
        _busy = false;
    }

    public IEnumerator Attack3()
    {
        LookAtObject(_player);
        _busy = true;
        _anim.SetTrigger("Attack3");
        LookAtObject(_player);
        yield return new WaitForSeconds(1.2f);
        _busy = false;
    }
    
    public void Jump()
    {
        //canAttack = false;
        //jumpHeight = 0.25f;
        _anim.SetBool("Jump", true);
        _rb.gravityScale = gravityScale;
        float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * _rb.gravityScale) * -2) * _rb.mass;
        _rb.velocity = new Vector2(0f, 0f);
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        if(_rb.velocity.y > 0) _rb.gravityScale = gravityScale;
        else _rb.gravityScale = fallGravityScale;
        if (_rb.velocity.y < -2f) _rb.velocity = new Vector2(_rb.velocity.x, -2f);
    }
    
    public IEnumerator Dash()
    {
        _cameraShake.ShakeCamera(5f);
        canDash = false;
        isDashing = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        _rb.gravityScale = originalGravity;
        _rb.velocity = new Vector2(0, 0);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void Fall()
    {
        if (_rb.velocity.y < -2f && _rb.velocity.y > -3f)
        {
            _anim.SetBool("Jump", false);
            _anim.SetBool("Fall", true);
        }
    }

    public int ObjectInZone(GameObject _object)
    {
        if (_object.transform.position.x < _point1.position.x) return 1;
        else if (_object.transform.position.x < _point2.position.x && _object.transform.position.x > _point1.position.x) return 2;
        return 3;
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HitRange")
        {
            Flip();
        }
        if (other.gameObject.tag == "Skill" && _currentState != "IdleState" && !_isAttack)
        {
        }
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