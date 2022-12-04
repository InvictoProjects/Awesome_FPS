using UnityEngine;

public class ChaseState : State
{
    public ChaseState(StateMachine stateMachine, EnemyController controller)
        : base(stateMachine, controller) { }

    public override void Enter()
    {
        _controller.Agent.speed = _controller.ChaseSpeed;
    }

    public override void Exit()
    {
        _controller.Agent.destination = _controller.transform.position;
        _controller.Agent.ResetPath();
    }

    public override void Update()
    {
        HandleTransitions();

        ChasePlayer();
    }

    private void HandleTransitions()
    {
        float distanceToPlayer = Vector3.Distance(_controller.transform.position, _controller.PlayerPosition);

        if (distanceToPlayer < _controller.AttackRange)
        {
            _stateMachine.ChangeState(_controller.AttackState);
        }

        if (distanceToPlayer > _controller.MaxVisionRange)
        {
            _stateMachine.ChangeState(_controller.PatrolState);
        }
    }

    private void ChasePlayer()
    {
        _controller.Agent.destination = _controller.PlayerPosition;
    }
}
