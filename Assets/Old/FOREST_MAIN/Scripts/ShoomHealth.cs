using System;
using UnityEngine;

public class ShoomHealth : MonoBehaviour
{
    private float _currentHealth;
    public float _maxHealth = 8f;
    [SerializeField] private GameObject _enemy;
    private float _damageNormal;
    private float _damageUlti;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _damageNormal = GameObject.Find("Data").GetComponent<SaveDataPlayer>().Value(21);
        _damageUlti = GameObject.Find("Data").GetComponent<SaveDataPlayer>().Value(22);
    }

    private void Update()
    {
        if (_currentHealth <= 0)
        {
            Destroy(_enemy);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Skill")
        {
            _currentHealth -= _damageNormal;
        }
        if (other.gameObject.tag == "SkillUlti")
        {
            _currentHealth = 0;
        }
    }
}
