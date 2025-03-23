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

    }
    public void Update()
    {
        MoveToObject2(_player);
    }
}
