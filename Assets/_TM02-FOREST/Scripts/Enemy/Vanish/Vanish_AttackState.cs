using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanish_AttackState : IState
{
    private Vanish _controller;
    private Animator _animator;
    private static readonly int Angry = Animator.StringToHash("Angry");

    public Vanish_AttackState(Vanish controller, Animator animator)
    {
        _controller = controller;
        _animator = animator;
    }
    public void Enter()
    {
        _animator.SetBool(Angry, true);
        _controller.SetSpeed(5f);
    }

    public void Execute()
    {
        _controller.MoveToPlayer();
    }

    public void Exit()
    {
        _animator.SetBool(Angry, false);
        _controller.SetSpeed(1f);
    }
}
