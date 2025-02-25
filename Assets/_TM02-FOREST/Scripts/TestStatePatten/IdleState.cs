using UnityEngine;

public class IdleStateN : IState
{
    private Subject _controller;
    public IdleStateN(Subject _subject)
    {
        _controller = _subject;
    }
    public void Enter()
    {
        Debug.Log("Idle Enter State");
    }

    public void Execute()
    {
        Debug.Log("Idle Execute State");
    }

    public void Exit()
    {
        Debug.Log("Idle Exit State");
    }   
}
