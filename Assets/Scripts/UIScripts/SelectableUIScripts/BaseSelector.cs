using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Audio))]
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Animator))]
public class BaseSelector : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler
{
    [SerializeField] private Transform _values = default;
    [SerializeField] private Image _leftArrowBackgroundImage = default;
    [SerializeField] private Image _leftArrowImage = default;
    [SerializeField] private Image _rightArrowBackgroundImage = default;
    [SerializeField] private Image _rightArrowImage = default;
    [SerializeField] private UnityEventInt _onSelect = default;
    protected Audio _audio;
    protected Button _button;
    protected Animator _animator;
    private int _currentSelectedIndex;


    void Awake()
    {
        _audio = GetComponent<Audio>();
        _button = GetComponent<Button>();
        _animator = GetComponent<Animator>();
    }

    void OnEnable()
	{
        CheckSelectorArrows();
    }

    private void CheckSelectorArrows()
    {
        Transform firstChild = _values.GetChild(0);
        Transform lastChild = _values.GetChild(_values.childCount - 1);
        if (firstChild.gameObject.activeSelf)
        {
            _leftArrowBackgroundImage.color = Color.black;
            _leftArrowImage.color = Color.white;
            _rightArrowBackgroundImage.color = Color.white;
            _rightArrowImage.color = Color.black;
            _leftArrowBackgroundImage.raycastTarget = false;
        }
        else if (lastChild.gameObject.activeSelf)
        {
            _leftArrowBackgroundImage.color = Color.white;
            _leftArrowImage.color = Color.black;
            _rightArrowBackgroundImage.color = Color.black;
            _rightArrowImage.color = Color.white;
            _rightArrowBackgroundImage.raycastTarget = false;
        }
        else
        {
            _leftArrowBackgroundImage.color = Color.white;
            _leftArrowImage.color = Color.black;
            _rightArrowBackgroundImage.color = Color.white;
            _rightArrowImage.color = Color.black;
            _rightArrowBackgroundImage.raycastTarget = true;
            _leftArrowBackgroundImage.raycastTarget = true;
        }
    }

    public void GoToNextSelectorValue()
    {
        if (_rightArrowBackgroundImage.raycastTarget)
        {
            _audio.Sound("Pressed").Play();
            for (int i = 0; i < _values.childCount; i++)
            {
                if (_values.GetChild(i).gameObject.activeSelf)
                {
                    _values.GetChild(i).gameObject.SetActive(false);
                    _values.GetChild(i + 1).gameObject.SetActive(true);
                    _currentSelectedIndex = i + 1;
                    if (_currentSelectedIndex < _values.childCount - 1)
                    {
                        _rightArrowBackgroundImage.raycastTarget = true;
                        _leftArrowBackgroundImage.raycastTarget = true;
                    }
                    else
                    {
                        _rightArrowBackgroundImage.raycastTarget = false;
                        _leftArrowBackgroundImage.raycastTarget = true;
                    }
                    CheckSelectorArrows();
                    _onSelect?.Invoke(_currentSelectedIndex);
                    return;
                }
            }
        }
    }

    public void GoToPreviousSelectorValue()
    {
        if (_leftArrowBackgroundImage.raycastTarget)
        {
            _audio.Sound("Pressed").Play();
            for (int i = 0; i < _values.childCount; i++)
            {
                if (_values.GetChild(i).gameObject.activeSelf)
                {
                    _values.GetChild(i).gameObject.SetActive(false);
                    _values.GetChild(i - 1).gameObject.SetActive(true);
                    _currentSelectedIndex = i - 1;
                    if (_currentSelectedIndex > 0)
                    {
                        _leftArrowBackgroundImage.raycastTarget = true;
                        _rightArrowBackgroundImage.raycastTarget = true;
                    }
                    else
                    {
                        _leftArrowBackgroundImage.raycastTarget = false;
                        _rightArrowBackgroundImage.raycastTarget = true;
                    }
                    CheckSelectorArrows();
                    _onSelect?.Invoke(_currentSelectedIndex);
                    return;
                }
            }
        }
    }

    public void ReSelectSelectable()
	{
        _button.Select();
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
        _button.Select();
    }

    public void SelectValue(BaseEventData eventData)
    {
        AxisEventData axisEventData = eventData as AxisEventData;
        if (axisEventData.moveDir == MoveDirection.Right)
        {
            GoToNextSelectorValue();
        }
        if (axisEventData.moveDir == MoveDirection.Left)
        {
            GoToPreviousSelectorValue();
        }
    }

    public int GetValue()
    {
        return _currentSelectedIndex;
    }

    public void SetValue(int value)
    {
        _values.GetChild(_currentSelectedIndex).gameObject.SetActive(false);
        _values.GetChild(value).gameObject.SetActive(true);
        CheckSelectorArrows();
        _onSelect?.Invoke(value);
    }
}
