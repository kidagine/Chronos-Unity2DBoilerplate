using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseSlider : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator _animator = default;
    [SerializeField] private EntityAudio _entityAudio = default;
    [SerializeField] private EventSystem _eventSystem = default;
    [SerializeField] private Slider _slider = default;
    [SerializeField] private float defaultValue = default;

    public float DefaultValue { get { return defaultValue; } private set { } }


    public void OnSelect(BaseEventData eventData)
    {
        _entityAudio.Sound("Selected").Play();
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
        //_entityAudio.Sound("Pressed").Play();
        //_animator.SetTrigger("Clicked");
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