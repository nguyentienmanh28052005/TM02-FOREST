using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Agis_BulletAttack3 : MonoBehaviour
{
    public float _speed;
    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed);
    }
}
