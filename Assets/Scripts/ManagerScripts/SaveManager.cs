using System;
using System.IO;
using System.Text;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    private CameraScreenshot _cameraScreenshot;
    private readonly int key = 02035;

	public int SelectedSaveSlot { get; set; }
	public bool IsLoading { get; private set; }

    
	void Start()
    {
        string savePath = Application.persistentDataPath;
        _cameraScreenshot = Camera.main.GetComponent<CameraScreenshot>();
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
    }

    public void Save(int saveSlot)
    {
        SaveData saveData = CreateSaveData(saveSlot);
        string json = JsonUtility.ToJson(saveData);
        string savePath = Application.persistentDataPath + saveSlot + ".save";
        File.WriteAllText(savePath, EncryptDecrypt(json, key));
    }

    public void Load(int saveSlot)
    {
        IsLoading = true;
        string savePath = Application.persistentDataPath + saveSlot + ".save";
        if (File.Exists(savePath))
        {
            string saveDataJson = File.ReadAllText(savePath);
            string decryptedSaveDataJson = EncryptDecrypt(saveDataJson, key);
            SaveData saveData = JsonUtility.FromJson<SaveData>(decryptedSaveDataJson);
            SceneDataCarrier.SetFloat("PlayerPositionX", saveData.playerPosition.x);
            SceneDataCarrier.SetFloat("PlayerPositionY", saveData.playerPosition.y);
            SceneDataCarrier.SetInt("PlayerCurrentHealth", saveData.playerCurrentHealth);
            LevelManager.Instance.GoToLevel(saveData.levelIndex);
        }
        else
        {
            LevelManager.Instance.GoToLevel(0);
        }
    }

    public void Delete(int saveSlot)
    {
        string savePath = Application.persistentDataPath + saveSlot + ".save";
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
    }

    private SaveData CreateSaveData(int saveSlot)
    {
        GameObject player = GameManager.Instance.GetPlayer();
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        SaveData saveData = new SaveData
        {
            saveSlotName = LevelManager.Instance.GetCurrentSceneName(),
            saveSlotDate = DateTime.Now.ToString("HH:mm"),
            saveSlotImagePath = _cameraScreenshot.TakeScreenshot(),
            playerPosition = player.transform.position,
            playerCurrentHealth = playerStats.currentHealth,
            saveSlotIndex = saveSlot,
            levelIndex = LevelManager.Instance.GetCurrentSceneIndex()
        };
        return saveData;
    }

    private string EncryptDecrypt(string data, int key)
    {
        StringBuilder input = new StringBuilder(data);
        StringBuilder output = new StringBuilder(data.Length);

        char character;
		for (int i = 0; i < data.Length; i++)
		{
            character = input[i];
            character = (char)(character ^ key);
            output.Append(character);
		}
        return output.ToString();
    }

    public SaveData GetSave(int saveSlot)
    {
        string savePath = Application.persistentDataPath + saveSlot + ".save";
        if (File.Exists(savePath))
        {
            string saveDataJson = File.ReadAllText(savePath);
            string decryptedSaveDataJson = EncryptDecrypt(saveDataJson, key);
            SaveData saveData = JsonUtility.FromJson<SaveData>(decryptedSaveDataJson);
            return saveData;
        }
        else
        {
            return null;
        }
    }
}
