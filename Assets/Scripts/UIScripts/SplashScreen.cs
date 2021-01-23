using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private Levels _levels = default;
    [Range(0.0f, 10.0f)]
    [SerializeField] private float _idleTime = 4.0f;
        

	void Start()
    {
        StartFadeTimers();
    }
    
    private async void StartFadeTimers()
    {
        await UpdateTimer.WaitFor(_idleTime);
        LevelManager.Instance.GoToLevel(_levels);
    }
}
