#if UNITY_EDITOR
using TMPro;
using UnityEngine;

public class PrinterMO : MonoBehaviour
{
    [SerializeField] private GameObject _textPrefab = default;
    [SerializeField] private Transform _printScrollViewContent = default;
    [SerializeField] private RectTransform _printerContainer = default;
    public static PrinterMO Instance { get; private set; }


    void Awake()
    {
        CheckInstance();
    }

    public void CheckInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void Log(Print print)
    {
        GameObject textPrefab = Instantiate(_textPrefab, _printScrollViewContent);
        TextMeshProUGUI printText = textPrefab.GetComponentInChildren<TextMeshProUGUI>();
        if (print.PrintToScreen)
        {
            printText.text = print.Message.ToString();
        }
        if (print.PrintToLog)
        {
            Debug.Log(print.Message);
        }
        if (print.TextColor != default)
        {
            printText.color = print.TextColor;
        }
        if (print.FlipToRight)
        {
            _printerContainer.anchorMax = new Vector2(1.0f, 0.0f);
            _printerContainer.anchorMin = new Vector2(1.0f, 0.0f);
            _printerContainer.anchoredPosition = new Vector2(_printerContainer.anchoredPosition.x * -1.0f, _printerContainer.anchoredPosition.y);
        }
        MoveContentDown();
        Destroy(textPrefab, print.Duration);
    }

    public void LogWarning(Print print)
    {
        GameObject textPrefab = Instantiate(_textPrefab, _printScrollViewContent);
        TextMeshProUGUI printText = textPrefab.GetComponentInChildren<TextMeshProUGUI>();
        if (print.PrintToScreen)
        {
            printText.text = print.Message.ToString();
        }
        if (print.PrintToLog)
        {
            Debug.LogWarning(print.Message);
        }
        if (print.TextColor != default)
        {
            printText.color = Color.yellow;
        }
        if (print.FlipToRight)
        {
            _printerContainer.anchorMax = new Vector2(1.0f, 0.0f);
            _printerContainer.anchorMin = new Vector2(1.0f, 0.0f);
            _printerContainer.anchoredPosition = new Vector2(_printerContainer.anchoredPosition.x * -1.0f, _printerContainer.anchoredPosition.y);
        }
        MoveContentDown();
        Destroy(textPrefab, print.Duration);
    }

    public void LogError(Print print)
    {
        GameObject textPrefab = Instantiate(_textPrefab, _printScrollViewContent);
        TextMeshProUGUI printText = textPrefab.GetComponentInChildren<TextMeshProUGUI>();
        if (print.PrintToScreen)
        {
            printText.text = print.Message.ToString();
        }
        if (print.PrintToLog)
        {
            Debug.LogError(print.Message);
        }
        if (print.TextColor != default)
        {
            printText.color = Color.red;
        }
        if (print.FlipToRight)
        {
            _printerContainer.anchorMax = new Vector2(1.0f, 0.0f);
            _printerContainer.anchorMin = new Vector2(1.0f, 0.0f);
            _printerContainer.anchoredPosition = new Vector2(_printerContainer.anchoredPosition.x * -1.0f, _printerContainer.anchoredPosition.y);
        }
        MoveContentDown();
        Destroy(textPrefab, print.Duration);
    }

    private void MoveContentDown()
    {
        if (_printScrollViewContent.childCount > 0)
        {
            int defaultGap = -50;
			for (int i = _printScrollViewContent.childCount - 1; i > -1; i--)
			{
                Transform childPrintText = _printScrollViewContent.GetChild(i);
                childPrintText.localPosition = new Vector2(childPrintText.localPosition.x, defaultGap);
                defaultGap -= 100;
            }
        }
    }
}
#endif