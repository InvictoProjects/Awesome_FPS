using System.Collections;
using UnityEngine;

public class HitState : State
{
    public HitState(StateMachine stateMachine, Animator animator, EnemyController controller)
        : base(stateMachine, animator, controller) { }

    public override void Enter()
    {
        _controller.Agent.destination = _controller.transform.position;
        _controller.Agent.isStopped = true;
    }

    public override void Exit()
    {
        _controller.Agent.isStopped = false;
        _animator.ResetTrigger("Hit");
    }

    public override void Update()
    {
        Hit();

        HandleTransitions();
    }

    private void HandleTransitions()
    {
        if (_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Hit"
            && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            float distanceToPlayer = Vector3.Distance(_controller.transform.position, _controller.PlayerPosition);

            if (distanceToPlayer > _controller.AttackRange)
            {
                _stateMachine.ChangeState(_controller.ChaseState);
            } else {
                _stateMachine.ChangeState(_controller.AttackState);
            }
        }
    }

    private void Hit()
    {
        _animator.SetTrigger("Hit");
    }
}
