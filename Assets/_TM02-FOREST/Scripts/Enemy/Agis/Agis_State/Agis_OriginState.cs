using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agis_OriginState : IState
{
    private Agis_Manager _agisManager;
    private Animator _animator;

    public Agis_OriginState(Agis_Manager manager, Animator animator)
    {
        _agisManager = manager;
        _animator = animator;
    }

    public void Enter()
    {
        
    }

    public void Execute()
    {
        _agisManager.SetOriginPositionAttack1();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
