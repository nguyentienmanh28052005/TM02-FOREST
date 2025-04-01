using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject _bomb;
    private int cnt = 0;
    private Vector2 _direction;
    private float speed;
    private Rigidbody2D _rb;
    void Start()
    {
        // _rb = GetComponent<Rigidbody2D>();
        // _rb.velocity = Vector2.left;
        // speed = 3f; //Random.Range(5, 20);
        // transform.Translate(_rb.velocity * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(_rb.velocity * Time.deltaTime * speed);
        // if (cnt == 2)
        // {
        //     
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Map"))
        {
            Vector3 spon = transform.position;
            spon.y -= 0.5f;
            GameObject fire = Instantiate(_bomb, spon, Quaternion.identity);
            fire.SetActive(true);
            Destroy(gameObject);
        }
    }
}
