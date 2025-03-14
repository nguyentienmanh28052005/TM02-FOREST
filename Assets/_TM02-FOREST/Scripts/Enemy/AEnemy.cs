using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public abstract class AEnemy : Subject
{
    [SerializeField] protected GameObject _player;
    protected bool _isFacingRight = true;
    protected Animator _anim;
    protected int _horizontal = 1;
    public float _speed = 1f;
    protected Rigidbody2D _rb;

    public void Attack()
    {
        
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

    public void MoveForward()
    {
        if (_isFacingRight) _horizontal = 1;
        else _horizontal = -1;
        _rb.velocity = new Vector2(_horizontal, _rb.velocity.y);
        transform.Translate(_rb.velocity * Time.deltaTime * _speed);
    }

    public void MoveToObject(GameObject _object)
    {
        LookAtObject(_object);
        MoveForward();
    }

    public void BackToHome()
    {
        
    }

    public void TakeDamage()
    {
        
    }
    
    public void Flip()
    {
        Vector3 size = transform.localScale;
        size.x = -1 * size.x;
        transform.localScale = size;
        _isFacingRight = !_isFacingRight;
    }
}
