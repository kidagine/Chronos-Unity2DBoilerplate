using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    private readonly string saveDataPath = "/saveData";


	void Start()
    {

        if (!Directory.Exists(Application.persistentDataPath + saveDataPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath + saveDataPath);
        }
    }

    public void Save()
    {
        SaveData saveData = CreateSaveData();
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + saveDataPath + "_0.save", json);
        Debug.Log("Saved game");
    }

    public void Load()
    {
        string saveDataJson = File.ReadAllText(Application.persistentDataPath + saveDataPath + "_0.save");
        SaveData saveData = JsonUtility.FromJson<SaveData>(saveDataJson);
        GameManager.Instance.GetPlayer().transform.position = saveData.playerPosition;
        SceneDataCarrier.SetInt("PlayerCurrentHealth", 1);
        LevelManager.Instance.GoToLevel(0);
        Debug.Log("Load game");
    }

    private SaveData CreateSaveData()
    {
        SaveData saveData = new SaveData
        {
            playerPosition = GameManager.Instance.GetPlayer().transform.position,
            saveSlotIndex = 0,
            sceneIndex = LevelManager.Instance.GetCurrentSceneIndex()
        };
        return saveData;
    }

    private SaveData[] GetSaves()
    {
        SaveData[] saveData = new SaveData[3];
        for (int i = 0; i < saveData.Length; i++)
        {
            string saveDataPath = Application.persistentDataPath + "/saveData" + i;
            if (File.Exists(saveDataPath))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(Application.persistentDataPath + saveDataPath, FileMode.Open);

                SaveData loadedSaveData = binaryFormatter.Deserialize(fileStream) as SaveData;
                fileStream.Close();
                saveData[i] = loadedSaveData;
            }
            else
            {
                saveData[i] = null;
            }
        }
        return saveData;
    }
}
