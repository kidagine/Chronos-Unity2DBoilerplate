using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Audio))]
[RequireComponent(typeof(Toggle))]
[RequireComponent(typeof(Animator))]
public class BaseToggle : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler
{
    [SerializeField] private Image _onImage = default;
    [SerializeField] private TextMeshProUGUI _onText = default;
    [SerializeField] private Image _offImage = default;
    [SerializeField] private TextMeshProUGUI _offText = default;
    [SerializeField] private UnityEventBool _onToggle = default;
    [SerializeField] private bool _isOn = true;
    protected Audio _audio;
    protected Toggle _toggle;
    protected Animator _animator;


    void Awake()
    {
        _audio = GetComponent<Audio>();
        _toggle = GetComponent<Toggle>();
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
        _toggle.Select();
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
        _toggle.Select();
    }

    public void ToggleOff()
    {
        _isOn = false;
        SetToggle(_isOn);
        _toggle.Select();
    }

    private void SetToggle(bool isOn)
    {
        //_audio.Sound("Pressed").Play();
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
