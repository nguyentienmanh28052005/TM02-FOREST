using System;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public class PlayerControllerTestStatePatten : Subject
{
    [SerializeField] private StateManager _stateManager;
    
    private void Start()
    {
        _stateManager = this.GetComponent<StateManager>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            _stateManager.ChangeState(new MovingState(this));
            return;
        }
        else
        {
            _stateManager.ChangeState(new IdleStateN(this));
        } 
    }
}
