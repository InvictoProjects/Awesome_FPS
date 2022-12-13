using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyHealth : HealthSystem
    {
        private EnemyController _controller;

        private void Start()
        {
            _controller = GetComponent<EnemyController>();
        }

        public override void Damage(float amount)
        {
            base.Damage(amount);
            PlayHitAnimation();
            Knockback();
        }

        private void PlayHitAnimation()
        {
            if (_controller.StateMachine.CurrentState != _controller.DeathState)
            {
                _controller.StateMachine.ChangeState(_controller.HitState);
            }
        }

        private void Knockback()
        {

        }

        public override void Die()
        {
            base.Die();
            _controller.StateMachine.ChangeState(_controller.DeathState);
            Destroy(gameObject, 5f);
        }
    }
}
