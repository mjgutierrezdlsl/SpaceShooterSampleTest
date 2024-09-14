using UnityEngine;

public class PlayerShip : Ship, IShooter
{
    [Header("Shooting")]
    [SerializeField] private Projectile _bullet;
    public Projectile Projectile => _bullet;
    [SerializeField] private Transform[] _spawnPoints;
    public Transform[] SpawnPoints => _spawnPoints;

    public PlayerShipController Controller { get; private set; }

    public void Initialize(PlayerShipController controller)
    {
        Controller = controller;
    }

    public void Shoot(Vector2 upDirection)
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            var bullet = Instantiate(_bullet, spawnPoint.position, Quaternion.identity);
            bullet.Move(upDirection);
        }
    }
}