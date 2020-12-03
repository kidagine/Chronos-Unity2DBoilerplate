using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private Image _splashScreenLogo = default;
    [Range(0.0f, 10.0f)]
    [SerializeField] private float _startWaitTime = 1.0f;
    [Range(0.0f, 10.0f)]
    [SerializeField] private float _fadeInTime = 1.0f;
    [Range(0.0f, 10.0f)]
    [SerializeField] private float _idleTime = 4.0f;
    [Range(0.0f, 10.0f)]
    [SerializeField] private float _fadeOutTime = 1.0f;
    [Range(0.0f, 10.0f)]
    [SerializeField] private float _endWaitTime = 1.0f;
        

	void Awake()
	{
        _splashScreenLogo.color = new Color(255.0f, 255.0f, 255.0f, 0.0f);
        StartFadeTimers();
    }
    
    private async void StartFadeTimers()
    {
        await UpdateTimer.WaitFor(_startWaitTime);
        CoroutineManager.Instance.ImageFade(ref _splashScreenLogo, _splashScreenLogo.color.a, 1.0f, _fadeInTime);
        await UpdateTimer.WaitFor(_idleTime);
        CoroutineManager.Instance.ImageFade(ref _splashScreenLogo, _splashScreenLogo.color.a, 0.0f, _fadeInTime);
        await UpdateTimer.WaitFor(_idleTime);
        SceneManager.LoadScene(1);
    }
}
