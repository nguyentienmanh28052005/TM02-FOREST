using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCrystal_Attack5_Controller : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _horizontal;
    private Animator _anim;
    public float _speed = 100f;

    private bool _stop = false; 
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _horizontal = transform.localScale.x;
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_stop)
        {
            _rb.velocity = new Vector2(_horizontal, _rb.velocity.y);
            transform.Translate(_rb.velocity * Time.deltaTime * _speed);
        }
        else _rb.velocity = new Vector2(0, 0);
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Map" || other.gameObject.tag == "Player")
        {
            _anim.SetTrigger("Impact");
            _speed = 0;
            _stop = true;
           StartCoroutine(Wait());
        }
    }
}