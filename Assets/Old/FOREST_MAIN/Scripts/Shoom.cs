using System;
using UnityEngine;

public class Shoom : MonoBehaviour
{

    [SerializeField] private GameObject _player;
    private Rigidbody2D _rb;
    private Animator _anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(_player.transform.position, this.transform.position) < 10f)
        {
            _anim.SetBool("Pop", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ShoomVer2")
        {
            _anim.SetBool("Hide", true);
            _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
