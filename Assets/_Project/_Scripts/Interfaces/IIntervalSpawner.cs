using UnityEngine;

public interface IIntervalSpawner
{
    Transform[] SpawnPoints { get; }
    float Interval { get; }
    GameObject SpawnObjectPrefab { get; }
}