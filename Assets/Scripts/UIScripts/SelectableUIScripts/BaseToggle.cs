using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Audio))]
public class BaseToggle : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EventSystem _eventSystem = default;
    [SerializeField] private Image _onImage = default;
    [SerializeField] private TextMeshProUGUI _onText = default;
    [SerializeField] private Image _offImage = default;
    [SerializeField] private TextMeshProUGUI _offText = default;
    [SerializeField] private UnityEventBool _onToggle = default;
    [SerializeField] private bool _isOn = true;
    private Animator _animator;
    private Audio _audio;

    public bool DefaultValue { get { return _isOn; } private set { } }


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
        if (_eventSystem.currentSelectedGameObject != gameObject)
        {
            _eventSystem.SetSelectedGameObject(gameObject);
        }
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
        if (_isOn)
        {
            _isOn = true;
            SetToggle(_isOn);
        }
        else
        {
            _isOn = false;
            SetToggle(_isOn);
        }
    }

    public void SetValue(bool value)
    {
        _isOn = value;
        SetToggle(_isOn);
    }

    public void Toggle()
    {
        _isOn = !_isOn;
        SetToggle(_isOn);
    }

    public void ToggleOn()
    {
        _isOn = true;
        SetToggle(_isOn);
        _eventSystem.SetSelectedGameObject(gameObject);
    }

    public void ToggleOff()
    {
        _isOn = false;
        SetToggle(_isOn);
        _eventSystem.SetSelectedGameObject(gameObject);
    }

    private void SetToggle(bool isOn)
    {
        //_entityAudio.Sound("Pressed").Play();
        if (isOn)
        {
            _onImage.color = Color.white;
            _onText.color = Color.black;
            _offImage.color = Color.black;
            _offText.color = Color.white;
        }
        else
        {
            _offImage.color = Color.white;
            _offText.color = Color.black;
            _onImage.color = Color.black;
            _onText.color = Color.white;
        }
        _onToggle?.Invoke(_isOn);
    }

    public bool GetValue()
    {
        return _isOn;
    }
}
