public class StateMachine
{
    private State _currentState;

    public State CurrentState { get => _currentState; }

    public void Initialize(State startingState)
    {
        _currentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(State newState)
    {
        _currentState.Exit();

        _currentState = newState;

        _currentState.Enter();
    }
}
