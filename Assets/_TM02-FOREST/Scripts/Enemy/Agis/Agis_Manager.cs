using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Agis_Manager : AEnemy
{
    private Animator _animator;
    [SerializeField] private GameObject _skill2Prefab;
    [SerializeField] private StateManager _stateManager;
    [SerializeField] private List<Hole> _holes = new List<Hole>();
    [SerializeField] private List<GameObject> _attack1OriginalPositions = new List<GameObject>();
    [SerializeField] private List<GameObject> _attack1AttackPositions = new List<GameObject>();
    [SerializeField] private List<GameObject> _pointAttack2 = new List<GameObject>();

    [SerializeField] private GameObject _bulletPrefab;

    public float _coolDown = 2f;
    private string _currentPointAttack2 = DefineValue.AGIS_ORIGINAL_POSITION;
    private bool _canAttack = true;
    
    public void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _stateManager = GetComponent<StateManager>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Attack2();
        Debug.Log(_canAttack);
    }

    public void Attack1()
    {
        _stateManager.ChangeState(new Agis_Attack1State(this, _animator));
        StartCoroutine(WaitExitAttack1());
    }

    public void Attack2()
    {
        if(!_busy) MoveAttack2();
        if (transform.position.x < _player.transform.position.x + 0.5f &&
            transform.position.x > _player.transform.position.x - 0.5f && _canAttack)
        {
            _canAttack = false;
            if (!_busy) StartCoroutine(SpawnBulletSkill2());
        }
        else if(transform.position.x > _player.transform.position.x + 0.5f ||
                transform.position.x < _player.transform.position.x - 0.5f) _canAttack = true;
    }
    
    public void MoveAttack2()
    {
        if (_currentPointAttack2 == DefineValue.AGIS_ORIGINAL_POSITION)
        {
            MoveToObject(_pointAttack2[2]);
            if (transform.position.x < _pointAttack2[2].transform.position.x + 0.5f &&
                transform.position.x > _pointAttack2[2].transform.position.x - 0.5f)
                _currentPointAttack2 = DefineValue.AGIS_RIGHT_POSITION;
        }
        if (_currentPointAttack2 == DefineValue.AGIS_LEFT_POSITION)
        {
            MoveToObject(_pointAttack2[2]);
            if (transform.position.x < _pointAttack2[2].transform.position.x + 0.5f &&
                transform.position.x > _pointAttack2[2].transform.position.x - 0.5f)
                _currentPointAttack2 = DefineValue.AGIS_RIGHT_POSITION;
        }
        if (_currentPointAttack2 == DefineValue.AGIS_RIGHT_POSITION)
        {
            MoveToObject(_pointAttack2[0]);
            if (transform.position.x < _pointAttack2[0].transform.position.x + 0.5f &&
                transform.position.x > _pointAttack2[0].transform.position.x - 0.5f)
                _currentPointAttack2 = DefineValue.AGIS_LEFT_POSITION;
        }
    }

    protected override void MoveToObject(GameObject _object)
    {
        if (!_busy)
        {
            LookAtObject(_object);
            MoveForward();
        }
    }
    
    public void SpawnSkull()
    {
        if (!_busy) StartCoroutine(Spawn());
    }

    private IEnumerator WaitExitAttack1()
    {
        yield return new WaitForSeconds(50f);
        _stateManager.ChangeState(new Agis_OriginalState(this, _animator));
    }

    private IEnumerator Spawn()
    {
        _busy = true;
        yield return new WaitForSeconds(4f);
        foreach (var hole in _holes)
        {
            Instantiate(_bulletPrefab, hole.transform.position, Quaternion.identity);
        }
        _busy = false;
    }

    private IEnumerator SpawnBulletSkill2()
    {
        _busy = true;
        _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        yield return new WaitForSeconds(0.1f);
        _skill2Prefab.SetActive(true);
        yield return new WaitForSeconds(2f);
        _skill2Prefab.SetActive(false);
        _rb.constraints = RigidbodyConstraints2D.None;
        _busy = false;
    }
    
    public void SetOriginalPositionAttack1()
    {
        if(_holes[0].GetCurrentPosition() == "Attack1") _holes[0].MoveToOriginPosition(_attack1OriginalPositions[0]);
        if(_holes[1].GetCurrentPosition() == "Attack1") _holes[1].MoveToOriginPosition(_attack1OriginalPositions[1]);
        if(_holes[2].GetCurrentPosition() == "Attack1") _holes[2].MoveToOriginPosition(_attack1OriginalPositions[2]);
        if(_holes[3].GetCurrentPosition() == "Attack1") _holes[3].MoveToOriginPosition(_attack1OriginalPositions[3]);
    }
    
    public void SetAttackPositionAttack1()
    {
        if(_holes[0].GetCurrentPosition() == "Origin") _holes[0].MoveToAttack1Position(_attack1AttackPositions[0]);
        if(_holes[1].GetCurrentPosition() == "Origin") _holes[1].MoveToAttack1Position(_attack1AttackPositions[1]);
        if(_holes[2].GetCurrentPosition() == "Origin") _holes[2].MoveToAttack1Position(_attack1AttackPositions[2]);
        if(_holes[3].GetCurrentPosition() == "Origin") _holes[3].MoveToAttack1Position(_attack1AttackPositions[3]);
    }
    
}
