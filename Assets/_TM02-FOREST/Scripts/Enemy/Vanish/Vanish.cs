using System;
using UnityEngine;

public class Vanish : AEnemy
{
    [SerializeField] private StateManager _stateManager;
    [SerializeField] private GameObject _right;
    [SerializeField] private GameObject _left;
    private bool _moveToLeft = true;
    private GameObject _object;

    public void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _stateManager = GetComponent<StateManager>();
        _object = _right;
        _stateManager.ChangeState(new Vanish_MoveState(this, _anim));
    }

    public void Update()
    {
        if(_player.transform.position.x < _right.transform.position.x && _player.transform.position.x > _left.transform.position.x)
            _stateManager.ChangeState(new Vanish_AttackState(this, _anim));
        else _stateManager.ChangeState(new Vanish_MoveState(this, _anim));
    }

    public void MoveInZone()
    {
        if(transform.position.x < _left.transform.position.x) _object = _right;
        if (transform.position.x > _right.transform.position.x) _object = _left;
        MoveToObject(_object);
    }

    public void MoveToPlayer()
    {
        if(transform.position.x > _player.transform.position.x + 1f ||
                   transform.position.x < _player.transform.position.x - 1f)
        MoveToObject(_player);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    
    
    
}
