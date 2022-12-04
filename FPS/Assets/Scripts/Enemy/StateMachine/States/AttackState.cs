using UnityEngine;

public class AttackState : State
{
    public AttackState(StateMachine stateMachine, EnemyController controller)
        : base(stateMachine, controller) { }

    public override void Enter()
    {
        _controller.Agent.destination = _controller.transform.position;
        _controller.Agent.isStopped = true;
    }

    public override void Exit()
    {
        _controller.Agent.isStopped = false;
    }

    public override void Update()
    {
        Attack();

        HandleTransitions();
    }

    private void HandleTransitions()
    {
        float distanceToPlayer = Vector3.Distance(_controller.transform.position, _controller.PlayerPosition);

        if (distanceToPlayer > _controller.AttackRange)
        {
            _stateMachine.ChangeState(_controller.ChaseState);
        }
    }

    private void Attack()
    {
        Debug.Log("Attack!");
    }
}
