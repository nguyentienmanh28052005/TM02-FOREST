using UnityEngine;

public class EnemyHealthBossRound2 : MonoBehaviour
{
    private float _currentHealth;
    public float _maxHealth;
    private DamageFlash _damageEffect;
    private Animator _anim;
    private Rigidbody2D _rb;
    private float _damageNormal;
    private float _damageUlti;
    private GameObject _key;
    private float _speed = 5f;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _damageEffect = GetComponentInParent<DamageFlash>();
        _anim = GetComponentInParent<Animator>();
        _rb = GetComponentInParent<Rigidbody2D>();
        _damageNormal = GameObject.Find("Data").GetComponent<SaveDataPlayer>().Value(21);
        _damageUlti = GameObject.Find("Data").GetComponent<SaveDataPlayer>().Value(22);
        _key = GameObject.Find("Key");
    }

    private void Update()
    {
        Debug.Log(_currentHealth);
        if (_currentHealth <= 0)
        {
             _anim.SetTrigger("Death");
            //GameObject key = Instantiate(_key, transform.position, transform.position);
            _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }

        if (_currentHealth <= 100f)
        {
            _speed = 10;
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Skill")
    //     {
    //         _anim.SetTrigger("Hit");
    //         _damageEffect.CallDamageFlash();
    //         _currentHealth -= _damageNormal;
    //         if (_currentHealth < 0) _currentHealth = 0;
    //     }
    //     if (other.gameObject.tag == "SkillUlti")
    //     {
    //         _anim.SetTrigger("Hit");
    //         _damageEffect.CallDamageFlash();
    //         _currentHealth -= _damageUlti;
    //         if (_currentHealth < 0) _currentHealth = 0;
    //     }
    //     
    // }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Skill")
        {
            //_anim.SetTrigger("Hit");
            _damageEffect.CallDamageFlash();
            _currentHealth -= _damageNormal;
            if (_currentHealth < 0) _currentHealth = 0;
        }
        if (other.gameObject.tag == "SkillUlti")
        {
            //_anim.SetTrigger("Hit");
            _damageEffect.CallDamageFlash();
            _currentHealth -= _damageUlti;
            if (_currentHealth < 0) _currentHealth = 0;
        }
        if (other.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlaySFX("Damage");
        } 
    }

    public float GetSpeed()
    {
        return _speed;
    }
    
}

