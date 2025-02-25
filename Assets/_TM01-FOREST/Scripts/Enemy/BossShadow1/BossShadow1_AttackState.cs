using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShadow1_AttackState : IState
{
    
    private Subject _controller;
    private Animator _anim;
    private int _attack;

    public BossShadow1_AttackState(Subject controller, Animator anim, int attack)
    {
        _controller = controller;
        _anim = anim;
        _attack = attack;
    }

    public void Enter()
    {
        BossShadow1_Manager._currentState = "AttackState";
        if(_attack == 1) _anim.SetTrigger("Attack1");
        else if(_attack == 2) _anim.SetTrigger("Attack2");
        else if(_attack == 3) _anim.SetTrigger("Attack3");
    }

    public void Execute()
    {
    }

    public void Exit()
    {
    }
}
