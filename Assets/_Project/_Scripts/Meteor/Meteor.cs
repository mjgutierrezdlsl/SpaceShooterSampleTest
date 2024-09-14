using UnityEngine;

public class Meteor : Projectile, IDamageable
{
    #region Health
    [Header("Health")]
    [SerializeField] private float _maxHealth = 5f;
    private float _currentHealth;
    private bool _isDestroyed;

    public float MaxHealth => _maxHealth;

    public float CurrentHealth
    {
        get
        {
            // Start from the MaxHealth if the default value is zero
            if (_currentHealth == 0 && !_isDestroyed)
            {
                return MaxHealth;
            }
            else
            {
                return _currentHealth;
            }
        }

        private set
        {
            _currentHealth = Mathf.Clamp(value, 0f, MaxHealth);
            _isDestroyed = _currentHealth == 0;
        }
    }

    public bool IsDestroyed => _isDestroyed;

    public virtual void TakeDamage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        if (IsDestroyed)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public override void Move(Vector2 upDirection)
    {
        Rigidbody2D.AddForce(upDirection * MovementSpeed);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        // We only destroy the meteor in the bounds if it has been blown off-course by the player
        // This is because the meteors can spawn beyond the bounds based on our MeteorSpawner script
        if (CurrentHealth < MaxHealth && other.CompareTag("Bounds"))
        {
            Destroy(gameObject);
        }
    }

    [Header("Appearance")]
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite[] _sprites;

    private void Start()
    {
        _spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Length)];
    }
}