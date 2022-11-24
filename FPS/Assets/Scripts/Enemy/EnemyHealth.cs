using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyHealth : HealthSystem
    {
        public override void Damage(float amount)
        {
            base.Damage(amount);
            PlayHitAnimation();
            Knockback();
        }

        private void PlayHitAnimation()
        {
            
        }

        private void Knockback()
        {

        }

        public override void Die()
        {
            base.Die();
            Destroy(gameObject);
        }
    }
}
