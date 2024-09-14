using UnityEngine;

public class MeteorSpawner : MonoBehaviour, IRandomIntervalSpawner
{
    [SerializeField] private Transform[] _spawnPoints;
    public Transform[] SpawnPoints => _spawnPoints;

    [SerializeField] private float _minSpawnInterval = 3f, _maxSpawnInterval = 5f;
    private float _spawnInterval;
    public float Interval => _spawnInterval;
    public float MinimumInterval => _minSpawnInterval;
    public float MaximumInterval => _maxSpawnInterval;

    [SerializeField] private GameObject _meteorPrefab;
    public GameObject SpawnObjectPrefab => _meteorPrefab;


    [SerializeField] private float _spawnRadius;
    [SerializeField] private Transform _planetTransform;

    private float _elapsedTime;

    private void Start()
    {
        _spawnInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }

    private void Update()
    {
        if (_elapsedTime < _spawnInterval)
        {
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            var meteor = Instantiate(_meteorPrefab, spawnPoint.position + (Vector3)Random.insideUnitCircle * _spawnRadius, Quaternion.identity).GetComponent<Meteor>();
            meteor.Move(_planetTransform.position - meteor.transform.position);
            _elapsedTime = 0f;
            _spawnInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
        }
    }
}