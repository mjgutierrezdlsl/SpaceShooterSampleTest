using UnityEngine;

public class EnemyShipSpawner : MonoBehaviour, IIntervalSpawner
{
    [SerializeField] private Transform[] _spawnPoints;
    public Transform[] SpawnPoints => _spawnPoints;

    [SerializeField] private float _spawnRadius;

    [SerializeField] private float _interval;
    public float Interval => _interval;

    [SerializeField] private GameObject _enemyShipPrefab;
    public GameObject SpawnObjectPrefab => _enemyShipPrefab;

    private float _elapsedTime;

    [SerializeField] private Transform _planetTransform;

    private void Update()
    {
        if (_elapsedTime < Interval)
        {
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            SpawnShips(_planetTransform);
            _elapsedTime = 0f;
        }
    }

    private void SpawnShips(Transform planetTransform)
    {
        var ship = Instantiate(SpawnObjectPrefab, (Vector2)SpawnPoints[Random.Range(0, SpawnPoints.Length)].position + Random.insideUnitCircle * _spawnRadius, Quaternion.identity).GetComponent<EnemyShip>();
        ship.Init(planetTransform);
    }
}