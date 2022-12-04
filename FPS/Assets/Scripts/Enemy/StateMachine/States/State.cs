using UnityEngine;

public abstract class State
{
    protected StateMachine _stateMachine;
    protected Animator _animator;
    protected EnemyController _controller;
    public State(StateMachine stateMachine, EnemyController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public State(StateMachine stateMachine, Animator animator, EnemyController controller)
    {
        _stateMachine = stateMachine;
        _animator = animator;
        _controller = controller;
    }

    public abstract void Enter();

    public abstract void Update();

    public abstract void Exit();
}
