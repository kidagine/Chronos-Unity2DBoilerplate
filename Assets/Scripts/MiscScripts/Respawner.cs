using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] private string _arrowPrefabName = default;
    [SerializeField] private float _timeUntilRespawn = 2.0f;
    private float _currentTimeUntilRespawn;


    void Update()
    {
        _currentTimeUntilRespawn -= Time.deltaTime;
        if (_currentTimeUntilRespawn <= 0.0f)
        {
            _currentTimeUntilRespawn = _timeUntilRespawn;
            ObjectPoolingManager.Instance.Spawn("Arrow", transform.position, Quaternion.identity);
        }
    }
}
