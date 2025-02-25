using UnityEngine;

public class BulletMushroomController : MonoBehaviour
{
    [SerializeField] private Transform _playerPosi;
    private Rigidbody2D _rb;
    private float speed;
    private Vector2 _direction;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _direction = _playerPosi.position - transform.position;
        _direction.Normalize();
        speed = 5f;
        transform.Translate(_direction * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( _direction* Time.deltaTime * speed);
    }
}
