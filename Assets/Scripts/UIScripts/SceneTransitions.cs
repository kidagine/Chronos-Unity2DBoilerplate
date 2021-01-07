using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SceneTransitions : MonoBehaviour
{
    [SerializeField] private Animator _animator = default;
    [SerializeField] private bool _fadeOutStart = true;

    void Start()
    {
        if (_fadeOutStart)
        {
            _animator.SetTrigger("FadeOut");
        }
    }

    public void FadeIn()
    {
        _animator.SetTrigger("FadeIn");
    }
}
