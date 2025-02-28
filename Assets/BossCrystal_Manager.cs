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
    private bool _isFacingRight = true;
    private Animator _anim;
    private int _horizontal = 1;
    public float _speed = 1f;
    private Rigidbody2D _rb;
    public static string _currentState;
    private bool _isAttack;
    
    public void Start()
    {
        _stateManager = GetComponent<StateManager>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        _stateManager.ChangeState(new BossShadow1_WalkState(this, _anim));
    }

    public void Update()
    {
        _anim.SetFloat("Speed", _speed);
        // if(Input.GetKeyDown(KeyCode.Q)) LookAtPlayer();
        if(_speed != 0f)
            MoveForward();
    }
    
    public void MoveForward()
    {
        if (_isFacingRight) _horizontal = 1;
        else _horizontal = -1;
        _rb.velocity = new Vector2(_horizontal, _rb.velocity.y);
        transform.Translate(_rb.velocity * Time.deltaTime * _speed);
    }
    
    public void LookAtPlayer()
    {
        if (transform.position.x - _player.transform.position.x > 0)
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

    public IEnumerator WaitFlip()
    {
        _rb.velocity = new Vector2(0, 0);
        _stateManager.ChangeState(new BossShadow1_IdleState(this, _anim));
        yield return new WaitForSeconds(1f);
        Flip();
        // yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(2f);
        _stateManager.ChangeState(new BossShadow1_WalkState(this, _anim));
    }
    
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HitRange")
        {
            StartCoroutine(WaitFlip());
        }
        if (other.gameObject.tag == "Skill" && _currentState != "IdleState" && !_isAttack)
        {
        }
    }

    
    
}