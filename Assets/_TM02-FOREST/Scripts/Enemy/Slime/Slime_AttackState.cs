using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_AttackState : IState
{
    private Slime _controller;
    private Animator _animator;
    
    public Slime_AttackState(Slime controller, Animator animator)
    {
        _controller = controller;
        _animator = animator;
    }
    public void Enter()
    {
        _animator.SetBool("Angry", true);
        _controller.SetSpeed(3f);
    }

    public void Execute()
    {
        _controller.MoveToPlayer();
    }

    public void Exit()
    {
        _animator.SetBool("Angry", false);
        _controller.SetSpeed(1f);
    }
}
