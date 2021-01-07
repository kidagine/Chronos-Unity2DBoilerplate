using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ControlledScrollView : MonoBehaviour
{
    [SerializeField] private RectTransform _content = default;
    [Range(0.01f, 10.0f)]
    [SerializeField] private float _scrollingSpeed = 1.0f;
    [Range(0.01f, 10.0f)]
    [SerializeField] private float _timeUntilOnEndInvoke = 1.0f;
    [SerializeField] private UnityEvent _onEnd = default;
    private float _topBound;
    private float _bottomBound;


	void Start()
	{
        LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
        _topBound = 0.0f;
        _bottomBound = _content.rect.height - 2160;
    }

	void Update()
    {
        MoveScrollView();
    }

    private async void MoveScrollView()
    {
        if (_content.anchoredPosition.y <= _bottomBound && _content.anchoredPosition.y >= _topBound)
        {
            _content.Translate(Vector2.up * (_scrollingSpeed / 2));
        }
        else
        {
            await UpdateTimer.WaitFor(_timeUntilOnEndInvoke);
            _onEnd.Invoke();
        }
    }
}
