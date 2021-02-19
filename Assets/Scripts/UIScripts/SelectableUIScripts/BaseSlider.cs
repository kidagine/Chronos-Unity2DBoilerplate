using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Audio))]
[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Animator))]
public class BaseSlider : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler
{
    [SerializeField] private float defaultValue = default;
    protected Audio _audio;
    protected Slider _slider;
    protected Animator _animator;


    void Awake()
    {
        _audio = GetComponent<Audio>();
        _slider = GetComponent<Slider>();
        _animator = GetComponent<Animator>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        _audio.Sound("Selected").Play();
        _animator.SetBool("IsSelected", true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        _animator.SetBool("IsSelected", false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _slider.Select();
    }

    public void ResetValue()
    {
        _slider.value = defaultValue;
    }

    public void OnValueChange()
    {
        if (_audio != null)
        {
            _audio.Sound("Pressed").Play();
        }
    }

    public void SetValue(float value)
    {
        _slider.value = value;
    }

    public float GetValue()
    {
        return _slider.value;
    }
}