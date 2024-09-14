using UnityEngine;

public abstract class Projectile : MonoBehaviour, IPhysicsMovable, IDamager
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    [SerializeField] float _movementSpeed;
    public float MovementSpeed => _movementSpeed;

    [SerializeField] float _damageAmount;
    public float DamageAmount => _damageAmount;

    public virtual void Move(Vector2 upDirection)
    {
        transform.up = upDirection;
        _rigidbody2D.AddForce(upDirection * _movementSpeed, ForceMode2D.Impulse);
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.rigidbody.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(_damageAmount);
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(_damageAmount);
            Destroy(gameObject);
        }
    }
}