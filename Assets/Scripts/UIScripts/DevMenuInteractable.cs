using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DevMenuInteractable : MonoBehaviour, ISelectHandler, IDeselectHandler
{
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

    void OnDisable()
	{
        _optionText.color = Color.white;
        _selectedImage.SetActive(false);
    }
}
