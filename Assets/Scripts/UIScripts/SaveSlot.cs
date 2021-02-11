using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour, ISelectHandler
{
    [SerializeField] private TextMeshProUGUI _saveSlotName;
    [SerializeField] private TextMeshProUGUI _saveSlotDate;
    [SerializeField] private Image _saveSlotImage;
    [SerializeField] private GameObject _saveSlotInformation;
    [SerializeField] private GameObject _saveSlotNewSaveText;
    [SerializeField] private int _saveSlotIndex;


	public void OnSelect(BaseEventData eventData)
	{
        SaveManager.Instance.SelectedSaveSlot = _saveSlotIndex;
	}

	public void SetSaveSlotInformation(string saveSlotName, string saveSlotDate, string saveSlotPath)
    {
        _saveSlotName.text = saveSlotName;
        _saveSlotDate.text = saveSlotDate;
        _saveSlotImage.sprite = SpriteImporter.LoadSprite(saveSlotPath);
    }

    public void SetSaveSlotToNew()
    {
        _saveSlotInformation.SetActive(false);
        _saveSlotNewSaveText.SetActive(true);
    }
}
