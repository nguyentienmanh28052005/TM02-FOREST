using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShadow1_IdleState : MonoBehaviour, IState
{
    private Subject _controller;
    private Animator _anim;

    public BossShadow1_IdleState(Subject controller, Animator anim)
    {
        _controller = controller;
        _anim = anim;
    }
    
    private void OnEnable()
    {
        
    }

    public void Enter()
    {
        BossShadow1_Manager._currentState = "IdleState";
        BossShadow1_Manager.speed = 0;
        _anim.SetFloat("Speed", BossShadow1_Manager.speed);
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
