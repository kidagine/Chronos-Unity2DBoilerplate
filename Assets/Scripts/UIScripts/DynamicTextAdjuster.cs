using TMPro;
using UnityEngine;

public class DynamicTextAdjuster : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text = default;
    [SerializeField] private Vector2 _fixedSize = new Vector2(400.0f, 100.0f);
    private readonly float _containerBaseIncrement = 100.0f;
    private readonly float _textBaseIncrement = 50.0f;


    void Start()
    {
        Vector2 textSize = _text.GetPreferredValues(_text.text);
        RectTransform textRectTransform = _text.GetComponent<RectTransform>();
        RectTransform containerRectTransform = transform.GetComponent<RectTransform>();

        containerRectTransform.sizeDelta = new Vector2(textSize.x + _containerBaseIncrement, _fixedSize.y);
        textRectTransform.sizeDelta = new Vector2(textSize.x + _textBaseIncrement, _fixedSize.y);
    }
}
