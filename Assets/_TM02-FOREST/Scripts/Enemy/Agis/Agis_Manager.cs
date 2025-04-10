using System;
using System.Collections;
using System.Collections.Generic;
using CitrioN.SettingsMenuCreator;
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
        Attack1(30f);
    }
    
    // protected override void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.E)) Attack2(20f);
    // }
    
    //Attack 1
    public void Attack1(float time)
    {
        _stateManager.ChangeState(new Agis_Attack1State(this, _animator));
        StartCoroutine(WaitExitAttack1(time));
    }
    
    public void SpawnSkull()
    {
        if (!_busy) StartCoroutine(Spawn());
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
    
    private IEnumerator WaitExitAttack1(float time)
    {
        yield return new WaitForSeconds(time);
        _stateManager.ChangeState(new Agis_OriginalState(this, _animator));
        yield return new WaitForSeconds(10f);
        Attack3(30f);

    }
    
    //Attack 2
    public void Attack2(float time)
    {
        _stateManager.ChangeState(new Agis_Attack2State(this, _animator));
        StartCoroutine(WaitExitAttack2(time));
    }
    public void Attack2MoveAndSpawnBullet()
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

    private IEnumerator SpawnBulletSkill2()
    {
        _busy = true;
        _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        yield return new WaitForSeconds(0.1f);
        _skill2Prefab.SetActive(true);
        yield return new WaitForSeconds(1f);
        _skill2Prefab.SetActive(false);
        _rb.constraints = RigidbodyConstraints2D.None;
        _busy = false;
    }

    public void MoveToOriginalPosition()
    {
        if (transform.position.x > _pointAttack2[1].transform.position.x + 0.1f ||
            transform.position.x < _pointAttack2[1].transform.position.x - 0.1f)
            MoveToObject(_pointAttack2[1]);
        else _rb.velocity = new Vector2(0f, 0f);
    }

    private IEnumerator WaitExitAttack2(float time)
    {
        yield return new WaitForSeconds(time);
        _stateManager.ChangeState(new Agis_OriginalState(this, _animator));
    }
    
    //Attack 3 
    public void Attack3(float time)
    {
        _stateManager.ChangeState(new Agis_Attack3State(this, _animator));
        StartCoroutine(WaitExitAttack3(time));
    }
    public void Attack3Update(int bullet)
    {
        if (!_busy) StartCoroutine(SpawnBulletAttack3(bullet));
    }
    
    private IEnumerator SpawnBulletAttack3(int _bullet)
    {
        _busy = true;
        yield return new WaitForSeconds(0.3f);
        _holes[_bullet].SpawnBullet();
        _busy = false;
    }
    
    private IEnumerator WaitExitAttack3(float time)
    {
        yield return new WaitForSeconds(time);
        _stateManager.ChangeState(new Agis_OriginalState(this, _animator));
        yield return new WaitForSeconds(10f);
        Attack2(30f);
    }

    public void SetHolesKinematic()
    {
        _holes[0].GetComponentInChildren<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        _holes[1].GetComponentInChildren<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        _holes[2].GetComponentInChildren<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        _holes[3].GetComponentInChildren<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
    
    public void SetHolesDynamic()
    {
        _holes[0].GetComponentInChildren<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        _holes[1].GetComponentInChildren<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        _holes[2].GetComponentInChildren<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        _holes[3].GetComponentInChildren<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    
    //Move
    protected override void MoveToObject(GameObject _object)
    {
        if (!_busy)
        {
            LookAtObject(_object);
            MoveForward();
        }
    }
}
