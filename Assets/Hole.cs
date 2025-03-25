using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private string _currentPosition = "Origin";

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
}
