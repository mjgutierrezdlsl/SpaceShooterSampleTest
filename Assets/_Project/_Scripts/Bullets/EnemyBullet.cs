using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Projectile
{
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        if (other.rigidbody.TryGetComponent<PlayerShip>(out var ship))
        {
            ship.Controller.MoveSpeed = 5f;
        }
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.CompareTag("Bounds"))
        {
            Destroy(gameObject);
        }
    }
}
