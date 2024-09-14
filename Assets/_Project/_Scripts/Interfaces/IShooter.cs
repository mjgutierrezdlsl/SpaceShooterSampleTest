using UnityEngine;

public interface IShooter
{
    Transform[] SpawnPoints { get; }
    Projectile Projectile { get; }
    abstract void Shoot(Vector2 upDirection);
}