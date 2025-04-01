using System;
using UnityEngine;

public class Shoom : MonoBehaviour
{

    private GameObject _player;
    private Rigidbody2D _rb;
    private Animator _anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(_player.transform.position, this.transform.position) < 10f)
        {
            _rb.constraints = RigidbodyConstraints2D.None;
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            _anim.SetBool("Pop", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ShoomVer2"))
        {
            _anim.SetBool("Hide", true);
            _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
