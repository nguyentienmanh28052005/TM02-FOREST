using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCrystal_MoveState : IState
{
    private BossCrystal_Manager _controller;
    private Animator _anim;
    
    public BossCrystal_MoveState(BossCrystal_Manager controller, Animator anim)
    {
        _controller = controller;
        _anim = anim;
    }
    public void Enter()
    {
    }

    public void Execute()
    {
        _controller.MoveForward();
    }

    public void Exit()
    {
    }
}
