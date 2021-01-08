using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SceneTransitions : MonoBehaviour
{
    [SerializeField] private Animator _animator = default;
    [SerializeField] private bool _fadeOutStart = true;
    [SerializeField] private bool _fadeOutSound = true;


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
        LevelManager.Instance.GoToCachedLevel();
    }

    public void FadeOutEndAnimationEvent()
    {
    }
}
