using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agis_OriginalState : IState
{
    private Agis_Manager _agisManager;
    private Animator _animator;
    private bool _complete = false;

    public Agis_OriginalState(Agis_Manager manager, Animator animator)
    {
        _agisManager = manager;
        _animator = animator;
    }

    public void Enter()
    {
        
    }

    public void Execute()
    {
        _agisManager.SetOriginalPositionAttack1();
        _agisManager.MoveToOriginalPosition();
    }

    public void Exit()
    {
        
    }
}
