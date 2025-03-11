using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly_Controller : MonoBehaviour
{
    private float _speed = 1f;
    private Vector2 _rotation;
    private float _time = 0f;


    private void Start()
    {
        _rotation = new Vector2(-1, 0.1f);
    }

    public void Update()
    {
        _time += Time.deltaTime;
        if (_time > 3f)
        {
            if (_rotation.y == 0.1f) _rotation.y = -0.1f;
            else _rotation.y = 0.1f;
            _time = 0f;
        }
        
        transform.Translate(_rotation * _speed * Time.deltaTime);
    }
}
