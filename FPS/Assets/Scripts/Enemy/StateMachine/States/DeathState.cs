using System.Collections;
using UnityEngine;

public class DeathState : State
{
    public DeathState(StateMachine stateMachine, Animator animator, EnemyController controller)
        : base(stateMachine, animator, controller) { }

    public override void Enter()
    {
        _controller.Agent.destination = _controller.transform.position;
        _controller.Agent.isStopped = true;
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        Die();
    }

    private void Die()
    {
        _animator.SetTrigger("Death");
    }
}
