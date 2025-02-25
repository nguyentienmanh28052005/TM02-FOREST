using System;
using UnityEngine;

public class VanishHealth : MonoBehaviour
{
    private float _currentHealth;
    public float _maxHealth = 6f;
    private DamageFlash _damageEffect;
    private Animator _anim;
    private float _damageNormal;
    private float _damageUlti;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _damageEffect = GetComponent<DamageFlash>();
        _anim = GetComponent<Animator>();
        _damageNormal = GameObject.Find("Data").GetComponent<SaveDataPlayer>().Value(21);
        _damageUlti = GameObject.Find("Data").GetComponent<SaveDataPlayer>().Value(22);
    }

    private void Update()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Skill")
        {
            _damageEffect.CallDamageFlash();
            _anim.SetTrigger("Hit");
            _currentHealth -= _damageNormal;
        }
        if (other.gameObject.tag == "SkillUlti")
        {
            _damageEffect.CallDamageFlash();
            _anim.SetTrigger("Hit");
            _currentHealth = 0;
        }
    }
}
