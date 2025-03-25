using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Subject
{
    private float _maxHealth;
    private float _currentHealth;
    private HealthBar _frameBar;
    private DamageFlash _damageFlash;
    private float _damage = 20f;

    public void Start()
    {
        _damageFlash = GetComponent<DamageFlash>();
        _maxHealth = SaveDataPlayer.Instance.Value(20);
        _currentHealth = _maxHealth;
    }

    public void Update()
    {
        if(_currentHealth <= 0 ) SceneController.Instance.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TakeDamage()
    {
        _currentHealth -= _damage;
        NotifyObservers(DefineValue.TAKE_DAMAGE);
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }
}
