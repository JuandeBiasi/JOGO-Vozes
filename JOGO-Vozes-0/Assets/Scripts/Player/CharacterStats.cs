using UnityEngine;
using System;

public class CharacterStats : MonoBehaviour
{
    [Header("Major Stats")]
    public Stat strength;
    public Stat agility;
    public Stat intelligence;
    public Stat vitality;

    [Header("Defensive Stats")]
    public Stat maxHealth;
    public Stat armor;
    public Stat evasion;

    public Stat damage;

    [SerializeField] private int currentHealth;

    public event Action<int, int> OnHealthChanged; // current, max
    public event Action<int> OnDamageTaken; // damage amount
    public event Action OnDied;

    protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();
        OnHealthChanged?.Invoke(currentHealth, maxHealth.GetValue());
    }

    public virtual void DoDamage(CharacterStats _targetStats)
    {
        if (CanAvoidAttack(_targetStats))
            return;

        var totalDamage = damage.GetValue() + strength.GetValue();
        totalDamage = CheckTargetArmor(_targetStats, totalDamage);
        _targetStats.TakeDamage(totalDamage);
    }

    private static int CheckTargetArmor(CharacterStats _targetStats, int totalDamage)
    {
        totalDamage -= _targetStats.armor.GetValue();
        return Mathf.Clamp(totalDamage, 0, int.MaxValue);
    }

    public virtual void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.GetValue());

        OnDamageTaken?.Invoke(_damage);
        OnHealthChanged?.Invoke(currentHealth, maxHealth.GetValue());

        if (currentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        OnDied?.Invoke();
    }

    private bool CanAvoidAttack(CharacterStats _targetStats)
    {
        var totalEvasion = _targetStats.evasion.GetValue() + _targetStats.agility.GetValue();
        return UnityEngine.Random.Range(0, 100) < totalEvasion;
    }

    protected void RecoverHealth(int foodHealthRestored)
    {
        foodHealthRestored = Mathf.Max(foodHealthRestored, 20);
        currentHealth = Mathf.Min(currentHealth + foodHealthRestored, maxHealth.GetValue());
        OnHealthChanged?.Invoke(currentHealth, maxHealth.GetValue());
    }
}