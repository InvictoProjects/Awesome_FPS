using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyHealth : HealthSystem
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public override void Damage(float amount)
        {
            base.Damage(amount);
            PlayHitAnimation();
            Knockback();
        }

        private void PlayHitAnimation()
        {
            _animator.SetTrigger("Impact");
        }

        private void Knockback()
        {

        }

        public override void Die()
        {
            _animator.SetTrigger("Death");
            base.Die();
            Destroy(gameObject);
        }
    }
}
