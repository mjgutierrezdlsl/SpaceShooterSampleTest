using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship, IShooter
{
    #region Shooting
    [Header("Shooting")]
    [SerializeField] private Transform[] _spawnPoints;
    public Transform[] SpawnPoints => _spawnPoints;

    [SerializeField] private Projectile _bullet;
    public Projectile Projectile => _bullet;

    [SerializeField] private float _interval;
    private float _elapsedTime;

    public void Shoot(Vector2 upDirection)
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            var bullet = Instantiate(_bullet, spawnPoint.position, Quaternion.identity);
            bullet.Move(upDirection);
        }
    }
    #endregion

    #region Movement
    [Header("Movement")]
    [SerializeField] private float _minDistanceThreshold = 7f;
    [SerializeField] private float _maxDistanceThreshold = 9f;
    private float _distanceThreshold;

    private Transform _planetTransform;
    private Vector2 _directionToPlanet;

    private bool _isWithinShootingRange;

    public void Init(Transform planetTransform)
    {
        _planetTransform = planetTransform;

        _distanceThreshold = Random.Range(_minDistanceThreshold, _maxDistanceThreshold);
    }

    private void Update()
    {
        _directionToPlanet = _planetTransform.position - transform.position;
        transform.up = _directionToPlanet;
        _isWithinShootingRange = _directionToPlanet.sqrMagnitude < _distanceThreshold * _distanceThreshold;

        if (_isWithinShootingRange)
        {
            if (_elapsedTime < _interval)
            {
                _elapsedTime += Time.deltaTime;
            }
            else
            {
                Shoot(transform.up);
                _elapsedTime = 0f;
            }
        }
    }
    private void FixedUpdate()
    {
        if (!_isWithinShootingRange)
        {
            Rigidbody2D.velocity = _directionToPlanet.normalized * MovementSpeed;
        }
        else
        {
            Rigidbody2D.velocity = Vector2.zero;
        }
    }
    #endregion
    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        if (!IsDestroyed) { return; }
        Destroy(gameObject);
    }
}
