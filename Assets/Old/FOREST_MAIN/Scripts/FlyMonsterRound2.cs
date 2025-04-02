using UnityEngine;

public class FlyMonsterRound2 : AEnemy
{
    [SerializeField] private GameObject _right;
    [SerializeField] private GameObject _left;
    private bool _moveToLeft = true;
    private GameObject _object;

    public void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _anim = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _object = _right;
    }

    public void Update()
    {
        MoveInZone();
    }

    public void MoveInZone()
    {
        if(transform.position.x < _left.transform.position.x) _object = _right;
        if (transform.position.x > _right.transform.position.x) _object = _left;
        MoveToObject(_object);
    }

    public void MoveToPlayer()
    {
        if(transform.position.x > _player.transform.position.x + 1f ||
           transform.position.x < _player.transform.position.x - 1f)
            MoveToObject(_player);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
