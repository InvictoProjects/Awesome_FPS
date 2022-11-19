using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _currentHealth;

        public event Action<float> OnHealthChanged;
        public event Action OnDeath;

        public float HealthPercantage { get => (float)_currentHealth / (float)_maxHealth; }

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void Damage(int amount)
        {
            _currentHealth -= amount;

            PlayHitAnimation();
            Knockback();

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                Die();
            }

            OnHealthChanged?.Invoke(HealthPercantage);
        }

        private void PlayHitAnimation()
        {
        }

        private void Knockback()
        {
        }

        private void Die()
        {
            OnDeath?.Invoke();
            GetComponent<Collider>().enabled = false;
        }
    }
}
