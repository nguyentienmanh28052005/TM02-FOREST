using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossRound2Main : MonoBehaviour
{
    private Rigidbody2D _rb;
    public Transform player;
    public bool isFlipped = false;
    private int speed = 12;
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;
    //[SerializeField] private ParticleEffect _particleDash;
    public float timeParticleDash;
    private int _horizontal = -1;
    [SerializeField] private GameObject _cam;
    private CameraShake _shake;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _shake = _cam.GetComponent<CameraShake>();

    }

    private void Update()
    {
        if(isDashing)
        {
            return;
        }
        // if (Input.GetKeyDown(KeyCode.M)  && canDash)
        // {
        //     StartDash();
        // }
    }
    
    void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
        Move();
    }
    
    

    public void LookAtPlayer()
    {
        // Vector3 flipped = transform.localScale;
        // flipped.z *= -1f;
        if (!isDashing)
        {
            if (transform.position.x > player.position.x && isFlipped)
            {
                //transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
                _horizontal *= -1;
            }
            else if (transform.position.x < player.position.x && !isFlipped)
            {
                //transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
                _horizontal *= -1;
            }
        }
        
    }

    public bool GetDirection()
    {
        return isFlipped;
    }

    public void Move()
    {
        Vector2 target = new Vector2(player.position.x, _rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(_rb.position, target, speed * Time.fixedDeltaTime);
        _rb.MovePosition(newPos);
        // _rb.velocity = new Vector2(_horizontal, _rb.velocity.y);
        // transform.Translate(_rb.velocity  * Time.deltaTime * 8f);
    }

    public void SetHorizontal(int horizontal)
    {
        _horizontal = horizontal;
    }

    public void SetSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    public void StartDash()
    {
        StartCoroutine(Dash());
    }

    private void Flip()
    {
        Vector3 kich_thuoc = transform.localScale;
        kich_thuoc.x = -1 * kich_thuoc.x;
        transform.localScale = kich_thuoc;
    }
    
    
    public IEnumerator Dash()
    {
        _shake.ShakeCamera(5f);
        canDash = false;
        isDashing = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(_horizontal * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        _rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}