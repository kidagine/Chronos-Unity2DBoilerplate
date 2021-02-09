using TMPro;
using UnityEngine;

public class SaveSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _saveSlotName;
    [SerializeField] private TextMeshProUGUI _saveSlotDate;
    [SerializeField] private GameObject _saveSlotInformation;
    [SerializeField] private GameObject _saveSlotNewSaveText;


    public void SetSaveSlotInformation(string saveSlotName, string saveSlotDate)
    {
        _saveSlotName.text = saveSlotName;
        _saveSlotDate.text = saveSlotDate.ToString();
    }

    public void SetSaveSlotToNew()
    {
        _saveSlotInformation.SetActive(false);
        _saveSlotNewSaveText.SetActive(true);
    }
}
