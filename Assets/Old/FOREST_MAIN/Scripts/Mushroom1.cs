using System;
using System.Collections;
using UnityEngine;

public class Mushroom1 : MonoBehaviour
{
    [SerializeField] private Transform _playerPosi;
    [SerializeField] private GameObject _bullet;
    private float time = 0;
    private bool first = true;
    public float rangeXL;
    public float rangeXR;
    private void Update()
    {
        if (_playerPosi.position.x > rangeXL && _playerPosi.position.x < rangeXR && first)
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
                if (_playerPosi.position.x > rangeXL && _playerPosi.position.x < rangeXR)
                {
                    GameObject bullet = Instantiate(_bullet, transform.position, transform.rotation);
                    bullet.SetActive(true);
                }
                time = 0;
            }
        }
    }
}
