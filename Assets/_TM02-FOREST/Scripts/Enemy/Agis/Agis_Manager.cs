using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Agis_Manager : AEnemy
{
    private Animator _animator;
    [SerializeField] private StateManager _stateManager;
    [SerializeField] private List<Hole> _holes = new List<Hole>();
    [SerializeField] private List<GameObject> _attack1OriginPositions = new List<GameObject>();
    [SerializeField] private List<GameObject> _attack1AttackPositions = new List<GameObject>();

    [SerializeField] private GameObject _bulletPrefab;

    public float _coolDown = 2f;
    
    public void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _stateManager = GetComponent<StateManager>();
        _stateManager.ChangeState(new Agis_Attack1State(this, _animator));
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) _stateManager.ChangeState(new Agis_OriginState(this, _animator));
    }

    public void SpawnSkull()
    {
        if (!_busy) StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        _busy = true;
        yield return new WaitForSeconds(4f);
        foreach (var hole in _holes)
        {
            Instantiate(_bulletPrefab, hole.transform.position, Quaternion.identity);
        }
        _busy = false;
    }

    public void SetOriginPositionAttack1()
    {
        if(_holes[0].GetCurrentPosition() == "Attack1") _holes[0].MoveToOriginPosition(_attack1OriginPositions[0]);
        if(_holes[1].GetCurrentPosition() == "Attack1") _holes[1].MoveToOriginPosition(_attack1OriginPositions[1]);
        if(_holes[2].GetCurrentPosition() == "Attack1") _holes[2].MoveToOriginPosition(_attack1OriginPositions[2]);
        if(_holes[3].GetCurrentPosition() == "Attack1") _holes[3].MoveToOriginPosition(_attack1OriginPositions[3]);
    }
    
    public void SetAttackPositionAttack1()
    {
        if(_holes[0].GetCurrentPosition() == "Origin") _holes[0].MoveToAttack1Position(_attack1AttackPositions[0]);
        if(_holes[1].GetCurrentPosition() == "Origin") _holes[1].MoveToAttack1Position(_attack1AttackPositions[1]);
        if(_holes[2].GetCurrentPosition() == "Origin") _holes[2].MoveToAttack1Position(_attack1AttackPositions[2]);
        if(_holes[3].GetCurrentPosition() == "Origin") _holes[3].MoveToAttack1Position(_attack1AttackPositions[3]);
    }
    
}
