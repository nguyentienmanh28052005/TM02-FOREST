using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agis_Attack3State : IState
{
    private Agis_Manager _manager;
    private Animator _anim;
    private int res;
    
    public Agis_Attack3State(Agis_Manager manager, Animator anim)
    {
        _manager = manager;
        _anim = anim;
    }
    public void Enter()
    {
        res = Random.Range(0, 4);
    }

    public void Execute()
    {
        _manager.Attack3Update(res);
    }

    public void Exit()
    {
        
    }
}
