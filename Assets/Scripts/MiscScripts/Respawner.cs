using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPrefab;
    [SerializeField] private float _timeUntilRespawn = 2.0f;
    private float _currentTimeUntilRespawn;


    void Update()
    {
        _currentTimeUntilRespawn -= Time.deltaTime;
        if (_currentTimeUntilRespawn <= 0.0f)
        {
            _currentTimeUntilRespawn = _timeUntilRespawn;
            ObjectPoolingManager.Instance.Spawn(_spawnPrefab, transform.position, Quaternion.identity);
        }
    }
}
