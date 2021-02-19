using UnityEngine;

[RequireComponent(typeof(Level))]
public class SplashScreen : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    [SerializeField] private float _waitTime = 4.0f;
    private Level _level;


	void Awake()
	{
        _level = GetComponent<Level>();
	}

	void Start()
    {
        StartFadeTimers();
    }
    
    private async void StartFadeTimers()
    {
        await UpdateTimer.WaitFor(_waitTime);
        LevelManager.Instance.GoToLevel(_level);
    }
}
