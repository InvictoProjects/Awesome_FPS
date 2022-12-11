using Assets.Scripts.Interfaces;
using Cinemachine;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class MeleeWeapon : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private CinemachineImpulseSource impulseSource;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable damagable) && other.CompareTag("Player"))
            {
                damagable.Damage(damage);

                impulseSource.GenerateImpulse();
            }
        }
    }
}
