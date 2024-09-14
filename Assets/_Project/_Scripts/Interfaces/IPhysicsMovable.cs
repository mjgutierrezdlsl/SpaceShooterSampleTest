using UnityEngine;

public interface IPhysicsMovable : IMovable
{
    Rigidbody2D Rigidbody2D { get; }
}