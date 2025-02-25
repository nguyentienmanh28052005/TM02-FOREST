using System;
using UnityEngine;

public class PlayerNarrationSystem : MonoBehaviour, IObserver
{

    [SerializeField] private Subject _playerSubject;
    private int _jumpCount = 0;
    public void OnNotify(PlayerAction action)
    {
        if (action == PlayerAction.Jump)
        {
            _jumpCount += 1;
        }
    }

    private void Update()
    {
        Debug.Log(_jumpCount);
    }

    private void OnEnable()
    {
        _playerSubject.AddObserver(this);
    }

    private void OnDisable()
    {
        _playerSubject.RemoveObserver(this);
    }
}
