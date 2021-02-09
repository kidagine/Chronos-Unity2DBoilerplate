using System.IO;
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

        Sprite NewSprite;
        Texture2D SpriteTexture = LoadTexture(saveSlotPath);
        NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0));

        _saveSlotImage.sprite = NewSprite;
    }

    public void SetSaveSlotToNew()
    {
        _saveSlotInformation.SetActive(false);
        _saveSlotNewSaveText.SetActive(true);
    }

    public Texture2D LoadTexture(string FilePath)
    {

        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails

        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        return null;                     // Return null if load failed
    }
}
