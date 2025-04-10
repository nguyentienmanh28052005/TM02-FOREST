using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agis_Attack2State : IState
{
    private Agis_Manager _manager;
    private Animator _animator;
    
    public Agis_Attack2State(Agis_Manager manager, Animator animator)
    {
        _manager = manager;
        _animator = animator;
    }
    
    public void Enter()
    {
        _manager.SetHolesKinematic();
    }

    public void Execute()
    {
        _manager.Attack2MoveAndSpawnBullet();
    }

    public void Exit()
    {
        _manager.SetHolesDynamic();
    }
}
