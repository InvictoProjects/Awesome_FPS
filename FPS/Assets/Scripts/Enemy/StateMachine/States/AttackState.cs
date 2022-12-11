using System.Collections;
using UnityEngine;

public class AttackState : State
{
    public AttackState(StateMachine stateMachine, Animator animator, EnemyController controller)
        : base(stateMachine, animator, controller) { }

    public override void Enter()
    {
        _controller.Agent.destination = _controller.transform.position;
        _controller.Agent.isStopped = true;
    }

    public override void Exit()
    {
        _controller.Agent.isStopped = false;
        _animator.ResetTrigger("Attack");
    }

    public override void Update()
    {
        Attack();

        HandleTransitions();
    }

    private void HandleTransitions()
    {
        if (_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Attack"
            && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
        {
            float distanceToPlayer = Vector3.Distance(_controller.transform.position, _controller.PlayerPosition);

            if (distanceToPlayer > _controller.AttackRange)
            {
                _stateMachine.ChangeState(_controller.ChaseState);
            }
        }
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
