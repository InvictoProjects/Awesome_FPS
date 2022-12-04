using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    public event Action<float, float> OnMaxHealthChanged;
    public event Action<float, float> OnCurrentHealthChanged;
    public event Action<float> OnDamaged;
    public event Action<float> OnHealed;
    public event Action OnDead;

    void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public float CurrentHealth => _currentHealth;

    public float MaxHealth => _maxHealth;

    public float HealthNormalized => _currentHealth / _maxHealth;

    public virtual void Damage(float amount)
    {
        _currentHealth -= amount;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        OnCurrentHealthChanged?.Invoke(HealthNormalized, CurrentHealth);
        OnDamaged?.Invoke(HealthNormalized);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        OnDead?.Invoke();
    }

    public bool IsDead()
    {
        return _currentHealth <= 0;
    }

    public virtual void Heal(float amount)
    {
        _currentHealth += amount;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        OnCurrentHealthChanged?.Invoke(HealthNormalized, CurrentHealth);
        OnHealed?.Invoke(HealthNormalized);
    }

    public virtual void HealComplete()
    {
        _currentHealth = _maxHealth;

        OnCurrentHealthChanged?.Invoke(HealthNormalized, CurrentHealth);
        OnHealed?.Invoke(HealthNormalized);
    }

    public void SetMaxHealth(float maxHealth, bool fullHealth)
    {
        _maxHealth = maxHealth;
        if (fullHealth)
        {
            _currentHealth = maxHealth;
        }

        OnMaxHealthChanged?.Invoke(HealthNormalized, MaxHealth);
        OnCurrentHealthChanged?.Invoke(HealthNormalized, CurrentHealth);
    }

    public void SetCurrentHealth(float health)
    {
        if (health > _maxHealth)
        {
            health = _maxHealth;
        }

        if (health < 0)
        {
            health = 0;
        }

        _currentHealth = health;

        OnCurrentHealthChanged?.Invoke(HealthNormalized, CurrentHealth);

        if (health <= 0)
        {
            Die();
        }
    }
}
