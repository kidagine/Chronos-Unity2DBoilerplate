using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
	void OnEnable()
    {


    }

    private void OnLevelLoaded()
    {
        GameObject player = GameManager.Instance.GetPlayer();
        SaveData[] saveData = GetSaves();
        if (saveData[1] != null && player != null)
        {
            player.transform.position = new Vector2(saveData[1]._playerPosition[0], saveData[1]._playerPosition[1]);
        }
    }

    void OnDisable()
    {
        GameManager.Instance.OnPlayerFound -= OnLevelLoaded;
    }

    public void Save()
    {
        SaveData saveData = CreateSaveData();
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string saveDataPath = Application.persistentDataPath + "/saveData" + saveData._saveSlotIndex;
        FileStream fileStream = new FileStream(saveDataPath, FileMode.Create);

        binaryFormatter.Serialize(fileStream, saveData);
        fileStream.Close();
    }

    private SaveData CreateSaveData()
    {
        Vector2 playerPosition = GameManager.Instance.GetPlayer().transform.position;
        int saveSlotIndex = 1;
        int sceneIndex = LevelManager.Instance.GetCurrentSceneIndex();
        SaveData saveData = new SaveData(playerPosition, saveSlotIndex, sceneIndex);
        return saveData;
    }

    public void Load()
    {
        SaveData[] saveData = GetSaves();
        GlobalSettings.PlayerPosition = new Vector2(saveData[1]._playerPosition[0], saveData[1]._playerPosition[1]);
        LevelManager.Instance.GoToLevel(saveData[1]._sceneIndex);
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
                FileStream fileStream = new FileStream(saveDataPath, FileMode.Open);

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
