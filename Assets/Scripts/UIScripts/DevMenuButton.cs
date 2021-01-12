using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DevMenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private DebugConsole _debugConsole = default;
    [SerializeField] private GameObject _currentMenu = default;
    [SerializeField] private GameObject _newMenu = default;
    [SerializeField] private GameObject _activeOption = default;
    [SerializeField] private TextMeshProUGUI _optionText = default;
    [SerializeField] private GameObject _selectedImage = default;


    public void OnSelect(BaseEventData eventData)
    {
        _optionText.color = Color.yellow;
        _selectedImage.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        _optionText.color = Color.white;
        _selectedImage.SetActive(false);
    }

    public void OnPress()
    {
        _debugConsole.OpenMenu(_newMenu, _currentMenu, _activeOption, transform.GetChild(0).gameObject);
    }
}
