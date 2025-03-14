using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_MoveState : IState
{
    private Slime _controller;
    private Animator _animator;
    
    public Slime_MoveState(Slime controller, Animator animator)
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
