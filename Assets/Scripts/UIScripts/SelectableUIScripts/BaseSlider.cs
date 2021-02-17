using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Audio))]
public class BaseSlider : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EventSystem _eventSystem = default;
    [SerializeField] private Slider _slider = default;
    [SerializeField] private float defaultValue = default;
    private Animator _animator;
    private Audio _audio;

    public float DefaultValue { get { return defaultValue; } private set { } }


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponent<Audio>();
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
        _eventSystem.SetSelectedGameObject(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_eventSystem.currentSelectedGameObject != gameObject)
        {
            _eventSystem.SetSelectedGameObject(null);
        }
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