public abstract class State
{
    protected StateMachine _stateMachine;
    protected EnemyController _controller;

    public State(StateMachine stateMachine, EnemyController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public abstract void Enter();

    public abstract void Update();

    public abstract void Exit();
}
