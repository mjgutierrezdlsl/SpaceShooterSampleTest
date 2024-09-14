public interface IDamageable
{
    float MaxHealth { get; }
    float CurrentHealth { get; }
    bool IsDestroyed { get; }
    abstract void TakeDamage(float damageAmount);
}