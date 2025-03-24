using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Agis_Manager : AEnemy
{
    [SerializeField] private List<GameObject> _attack1OriginPositions = new List<GameObject>();
    [SerializeField] private List<GameObject> _attack1AttackPositions = new List<GameObject>();

    [SerializeField] private GameObject _bulletPrefab;
    
    public void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) Skill1();
    }

    public void Skill1()
    {
        int _res = Random.Range(0, 4);
        Instantiate(_bulletPrefab, _attack1OriginPositions[_res].transform.position, Quaternion.identity);
    }
}
