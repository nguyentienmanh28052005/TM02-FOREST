using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private float _currentHealth;
    private float _maxHealth;
    [SerializeField] private GameObject _healthBar;
    private HealthBar _frameBar;
    private DamageFlash _damageFlash;
    private AudioSource _audio;
    private UIController _UI;
    private SaveDataPlayer _data;
    private bool check = true;
    private int _nameScene;
    private Animator _anim;




    private void Start()
    {
        _frameBar = _healthBar.GetComponent<HealthBar>();
        _damageFlash = GetComponent<DamageFlash>();
        _currentHealth = _maxHealth;
        _audio = GetComponent<AudioSource>();
        _UI = GetComponent<UIController>();
        _data = GameObject.Find("Data").GetComponent<SaveDataPlayer>();
        _maxHealth = _data.Value(20);
        _currentHealth = _maxHealth;
        _nameScene = GameObject.Find("Scene").GetComponent<SceneO>().Name();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log(_maxHealth);
        if (_currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trap")
        {
            //_audio.Play();
            _currentHealth -= 20;
            _frameBar.UpdateBar(_currentHealth, _maxHealth);
            _damageFlash.CallDamageFlash();
        }
        if (other.gameObject.tag == "SkipRound")
        {
            _anim.SetTrigger("Shade");
            float atLevel = _data.GetComponent<SaveDataPlayer>().Value(30);
            atLevel = _nameScene - 1;
            _data.Save(30, atLevel);
            StartCoroutine(DelaySkipRound());
        }
        if (other.gameObject.tag == "Enemy")
        {
            _currentHealth -= 20;
            _frameBar.UpdateBar(_currentHealth, _maxHealth);
            _damageFlash.CallDamageFlash();
        }
    }

    private IEnumerator DelaySkipRound()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(_nameScene + 1);
        if (_nameScene + 1 == 3)
        {
            AudioManager.Instance.PlayMusic("Round2");
            AudioManager.Instance.PlayMusic2("None");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _currentHealth -= 20;
            _frameBar.UpdateBar(_currentHealth, _maxHealth);
            _damageFlash.CallDamageFlash();
        }
    }
}
