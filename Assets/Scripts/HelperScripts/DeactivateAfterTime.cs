using UnityEngine;

public class DeactivateAfterTime : MonoBehaviour
{
    [SerializeField] private float _timeUntilDeactivate = default;
    private float _currentTimeUntilDeactivate;


	void Update()
	{
        _currentTimeUntilDeactivate -= Time.deltaTime;
        if (_currentTimeUntilDeactivate <= 0.0f)
        {
            _currentTimeUntilDeactivate = _timeUntilDeactivate;
            gameObject.SetActive(false);
        }
    }

	void OnEnable()
	{
        _currentTimeUntilDeactivate = _timeUntilDeactivate;
    }
}
