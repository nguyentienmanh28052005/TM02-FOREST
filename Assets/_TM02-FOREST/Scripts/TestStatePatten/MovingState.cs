using UnityEngine;

public class MovingState : IState
{
    private Subject _controller;
    public MovingState(Subject _subject)
    {
        _controller = _subject;
    }
    public void Enter()
    {
        Debug.Log("Moving Enter State");
    }

    public void Execute()
    {
        Debug.Log("Moving Execute State");
    }

    public void Exit()
    {
        Debug.Log("Moving Exit State");
    }   
}
