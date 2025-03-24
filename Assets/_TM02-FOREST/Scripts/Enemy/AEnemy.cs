using System;
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
    protected bool _busy;
    private static readonly int Hit = Animator.StringToHash("Hit");

    public void Attack()
    {
        
    }

    protected void LookAtObject(GameObject _object)
    {
        if (transform.position.x - _object.transform.position.x > 0)
        {
            if(_isFacingRight) Flip();
        }
        else 
        if(!_isFacingRight) Flip();
    }

    protected void LookAtObject2(GameObject _object)
    {
        Vector2 direction = (_object.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    protected void MoveToObject2(GameObject _object)
    { 
        LookAtObject2(_object);
        transform.position = Vector3.MoveTowards(transform.position, _object.transform.position, Time.deltaTime * _speed);
    }
    
    public void MoveForward()
    {
        if (_isFacingRight) _horizontal = 1;
        else _horizontal = -1;
        _rb.velocity = new Vector2(_horizontal, _rb.velocity.y);
        transform.Translate(_rb.velocity * Time.deltaTime * _speed);
    }

    protected void MoveToObject(GameObject _object)
    {
        LookAtObject(_object);
        MoveForward();
    }
    

    protected void BackToHome()
    {
        
    }

    protected virtual void TakeDamage()
    {
        _anim.SetTrigger(Hit);
        StartCoroutine(Wait());
    }

    protected IEnumerator Wait()
    {
        _busy = true;
        _speed = 0;
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(1f);
        _speed = 3f;
        _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        _busy = false;
    }
    
    protected void Flip()
    {
        Vector3 size = transform.localScale;
        size.x = -1 * size.x;
        transform.localScale = size;
        _isFacingRight = !_isFacingRight;
    }

    protected virtual IEnumerator Death(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Skill") && !_busy)
        {
            TakeDamage();
        }
        if (other.CompareTag("SkillUlti") && !_busy)
        {
            TakeDamage();
        }
    }
    
}
