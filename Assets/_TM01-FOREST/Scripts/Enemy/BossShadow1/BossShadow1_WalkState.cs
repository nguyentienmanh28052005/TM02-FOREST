using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShadow1_WalkState : IState
{
    private Subject _controller;
    private Animator _anim;

    public BossShadow1_WalkState(Subject controller, Animator anim)
    {
        _controller = controller;
        _anim = anim;
    }
    public void Enter()
    {
        BossShadow1_Manager._currentState = "WalkState";
        BossShadow1_Manager.speed = 1f;
        _anim.SetFloat("Speed", BossShadow1_Manager.speed);
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
