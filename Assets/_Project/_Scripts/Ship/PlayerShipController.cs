using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    [SerializeField] private Vector2 _shipSpawnOffset = new(0f, 5f);
    [SerializeField] private PlayerShip _playerShipPrefab;
    [SerializeField] private Transform _playerShipAnchor;

    private PlayerShip _currentShip;
    public float MoveSpeed;

    private void Start()
    {
        _currentShip = Instantiate(_playerShipPrefab, _playerShipAnchor);
        _currentShip.Initialize(this);
        _currentShip.transform.position += (Vector3)_shipSpawnOffset;
    }

    private void Update()
    {
        var direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        _playerShipAnchor.Rotate(Vector3.forward, -direction.x * _currentShip.MovementSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentShip.Shoot(_currentShip.transform.up);
        }
    }
}