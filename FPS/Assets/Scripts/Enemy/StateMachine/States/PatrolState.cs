using UnityEngine;

public class PatrolState : State
{
    private int _pointIndex;
    private float _waitTime;

    public PatrolState(StateMachine stateMachine, EnemyController controller)
        : base(stateMachine, controller) { }

    public override void Enter()
    {
        _controller.Agent.destination = _controller.PatrolPoints[_pointIndex].position;
        _controller.Agent.speed = _controller.PatrolSpeed;
    }

    public override void Exit()
    {
        _controller.Agent.ResetPath();
    }

    public override void Update()
    {
        HandleTransitions();

        PatrolCycle();
    }

    private void HandleTransitions()
    {
        float distanceToPlayer = Vector3.Distance(_controller.transform.position, _controller.PlayerPosition);

        if (distanceToPlayer < _controller.MinVisionRange)
        {
            _stateMachine.ChangeState(_controller.ChaseState);
        }
    }

    private void PatrolCycle()
    {
        if (_controller.PatrolPoints.Length == 0)
        {
            return;
        }

        if (_controller.Agent.remainingDistance < 0.2f)
        {
            _waitTime += Time.deltaTime;

            if (_waitTime > 1)
            {
                _pointIndex = (_pointIndex + 1) % _controller.PatrolPoints.Length;

                _controller.Agent.destination = _controller.PatrolPoints[_pointIndex].position;

                _waitTime = 0;
            }
        }
    }
}
