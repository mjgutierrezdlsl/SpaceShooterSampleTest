using UnityEngine;

public interface IRandomIntervalSpawner : IIntervalSpawner
{
    float MinimumInterval { get; }
    float MaximumInterval { get; }
}