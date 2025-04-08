using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class Skull_Manager : AEnemy
{
    private Vector3 _targetPos;
    public void Start()
    {
        _player = GameObject.FindGameObjectWithTag("PlayerPos");
        _targetPos = new Vector3(_player.transform.position.x, _player.transform.position.y + 1f,
            _player.transform.position.z);
        _anim = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();

    }
    protected override void Update()
    {
        if(!_busy) MoveToObject2D(_player);
    }

    protected override void TakeDamage()
    {
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        base.TakeDamage();
        StartCoroutine(Death(0.4f));
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Skill") || other.CompareTag("Player"))
        {
           TakeDamage();
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TakeDamage();
        }
    }
}
