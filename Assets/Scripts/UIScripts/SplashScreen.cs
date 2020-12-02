using System.Collections;
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
    private bool _hasEndedFadeIn;
    private bool _hasEndedFadeOut;
        

	void Awake()
	{
        _splashScreenLogo.color = new Color(255.0f, 255.0f, 255.0f, 0.0f);
    }

	void Update()
	{
        if (!_hasEndedFadeIn)
        {
            _startWaitTime -= Time.deltaTime;
            if (_startWaitTime < 0.0f)
            {
                StartCoroutine(Lerp(_splashScreenLogo.color.a, 1.0f, _fadeInTime));
            }
        }

        if (_hasEndedFadeIn)
        {
            _idleTime -= Time.deltaTime;
            if (_idleTime < 0.0f)
            {
                StartCoroutine(Lerpf(_splashScreenLogo.color.a, 0.0f, _fadeInTime));
            }
        }

        if (_hasEndedFadeOut)
        {
            _endWaitTime -= Time.deltaTime;
            if (_startWaitTime < 0.0f)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

	IEnumerator Lerp(float startValue, float endValue, float duration)
    {
        float elapsedTime = 0;
        float returnedValue;
        while (elapsedTime < duration)
        {
            returnedValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            _splashScreenLogo.color = new Color(255, 255, 255, returnedValue);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _splashScreenLogo.color = new Color(255, 255, 255, endValue);
        _hasEndedFadeIn = true;
    }

    IEnumerator Lerpf(float startValue, float endValue, float duration)
    {
        float elapsedTime = 0;
        float returnedValue;
        while (elapsedTime < duration)
        {
            returnedValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            _splashScreenLogo.color = new Color(255, 255, 255, returnedValue);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _splashScreenLogo.color = new Color(255, 255, 255, endValue);
        _hasEndedFadeOut = true;
    }
}
