using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SceneTransitions : MonoBehaviour
{
    [SerializeField] private bool _fadeOutStart = true;
    [SerializeField] private bool _fadeOutSound = true;
    private Animator _animator = default;

    public event Action OnFadeIn;
    public event Action OnFadeOut;


	void Awake()
	{
        _animator = GetComponent<Animator>();
	}

	void Start()
    {
        if (_fadeOutStart)
        {
            if (_fadeOutSound)
            {
                SoundManager.Instance.FadeInMasterVolume();
            }
            _animator.SetTrigger("FadeOut");
        }
    }

    public void FadeIn()
    {
        SoundManager.Instance.FadeOutMasterVolume();
        _animator.SetTrigger("FadeIn");
    }

    public void FadeInEndAnimationEvent()
    {
        OnFadeIn?.Invoke();
    }

    public void FadeOutEndAnimationEvent()
    {
        OnFadeOut?.Invoke();
    }
}
