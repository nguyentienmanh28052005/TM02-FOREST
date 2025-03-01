using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCrystal_AttackState : IState
{
    private BossCrystal_Manager _controller;
    private Animator _anim;
    private int _attack;
    
    public BossCrystal_AttackState(BossCrystal_Manager controller, Animator anim, int attack)
    {
        _controller = controller;
        _anim = anim;
        _attack = attack;
    }

    public void Enter()
    {
    }

    public void Execute()
    {
    }

    public void Exit()
    {
    }
}
