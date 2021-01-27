﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseSlider : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator _animator = default;
    [SerializeField] private EntityAudio _entityAudio = default;
    [SerializeField] private EventSystem _eventSystem = default;
    [SerializeField] private Slider _slider = default;

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

    public void OnValueChange()
    {
        ////_entityAudio.Play("Pressed");
        //_animator.SetTrigger("Clicked");
    }

    public void SetValue(float value)
    {
        _slider.value = value;
    }
}