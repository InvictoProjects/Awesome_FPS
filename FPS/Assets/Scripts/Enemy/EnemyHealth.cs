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
            SkinnedMeshRenderer[] skinnedMeshes = GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (var skinnedMesh in skinnedMeshes)
            {
                skinnedMesh.material.color = Color.white;
            }

            //SkinnedMeshRenderer skinnedMeshMain = GetComponentInChildren<SkinnedMeshRenderer>();
            //skinnedMeshMain.material.color = Color.white;
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
