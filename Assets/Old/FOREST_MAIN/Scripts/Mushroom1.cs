using System;
using System.Collections;
using UnityEngine;

public class Mushroom1 : MonoBehaviour
{
    private Transform _playerPosi;
    [SerializeField] private GameObject _bullet;
    private float time = 0;
    private bool first = true;
    private float _rangeXL;
    private float _rangeXR;

    public void Start()
    {
        _playerPosi = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        _rangeXL = transform.position.x - 10f; 
        _rangeXR = transform.position.x + 10f; 

    }

    private void Update()
    {
        if (_playerPosi.position.x > _rangeXL && _playerPosi.position.x < _rangeXR && first)
        {
            GameObject bullet = Instantiate(_bullet, transform.position, transform.rotation);
            bullet.SetActive(true);
            first = !first;
        }
        else
        {
            time += Time.deltaTime;
            if (time > 5)
            {
                if (_playerPosi.position.x > _rangeXL && _playerPosi.position.x < _rangeXR)
                {
                    GameObject bullet = Instantiate(_bullet, transform.position, transform.rotation);
                    bullet.SetActive(true);
                }
                time = 0;
            }
        }
    }
}
