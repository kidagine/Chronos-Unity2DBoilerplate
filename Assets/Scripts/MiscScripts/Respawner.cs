using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] private GameObject _respawnObject = default;
    [SerializeField] private float _timeBetweenRespawn = 2.0f;



    void Start()
    {
        RespawnObjectOverTime();
    }

    private async void RespawnObjectOverTime()
    {
        while (_respawnObject != null)
        {
            await UpdateTimer.WaitFor(_timeBetweenRespawn);
            Instantiate(_respawnObject, transform.position, Quaternion.identity);
        }
    }
}
