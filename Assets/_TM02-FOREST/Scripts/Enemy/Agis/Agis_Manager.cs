using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agis_Manager : AEnemy
{
    public void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        
    }
}
