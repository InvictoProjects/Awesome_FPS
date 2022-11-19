using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Player.Characteristics
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _currentHealth;

        public event Action<float> OnHealthHealed;
        public event Action<float> OnHealthDamaged;

        public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
        public float HealthPercantage { get => _currentHealth / (float)_maxHealth; }

        public void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void Damage(int amount)
        {
            _currentHealth -= amount;

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                Die();
            }

            OnHealthDamaged?.Invoke(HealthPercantage);
        }

        public void Heal(int amount)
        {
            _currentHealth += amount;

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }

            OnHealthHealed?.Invoke(HealthPercantage);
        }

        public void ResetHealth()
        {
            _currentHealth = _maxHealth;
            OnHealthHealed?.Invoke(HealthPercantage);
        }

        private void Die()
        {
            Debug.Log($"Health: {_currentHealth}");
        }
    }
}
