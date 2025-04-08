using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private string _currentPosition = "Origin";
    [SerializeField] private GameObject _prefab;
    private Pendulum _pendulum;
    [SerializeField] private GameObject _rotationBullet;

    private void Start()
    {
        _pendulum = GetComponentInChildren<Pendulum>();
        _pendulum.moveSpeed = 0f;
    }
    
    public void MoveToAttack1Position(GameObject _gameObject)
    {
        transform.position =
            Vector3.MoveTowards(transform.position, _gameObject.transform.position, 5f * Time.deltaTime);
        if (transform.position.x < _gameObject.transform.position.x + 0.1f &&
            transform.position.x > _gameObject.transform.position.x - 0.1f)
            _currentPosition = "Attack1";
    }
    
    public void MoveToOriginPosition(GameObject _gameObject)
    {
        transform.position =
            Vector3.MoveTowards(transform.position, _gameObject.transform.position, 5f * Time.deltaTime);
        if (transform.position.x < _gameObject.transform.position.x + 0.1f &&
            transform.position.x > _gameObject.transform.position.x - 0.1f)
            _currentPosition = "Origin";
    }

    public string GetCurrentPosition()
    {
        return _currentPosition;
    }

    public void SpawnBullet()
    {
        _pendulum.moveSpeed = 100;
        Debug.Log("hi");
        Instantiate(_prefab, _rotationBullet.transform.position, _rotationBullet.transform.rotation);
    }
}
