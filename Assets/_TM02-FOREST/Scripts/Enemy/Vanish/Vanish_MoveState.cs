using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanish_MoveState : IState
{
    private Vanish _controller;
    private Animator _animator;
    
    public Vanish_MoveState(Vanish controller, Animator animator)
    {
        _controller = controller;
        _animator = animator;
    }
    public void Enter()
    {
        
    }

    public void Execute()
    {
        _controller.MoveInZone();
    }

    public void Exit()
    {
        
    }
}
