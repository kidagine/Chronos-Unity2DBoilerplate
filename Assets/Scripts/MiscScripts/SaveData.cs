using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    public float[] _playerPosition = new float[2];
    public int _saveSlotIndex;
    public int _sceneIndex;


    public SaveData(Vector2 playerPosition, int saveSlotIndex, int sceneIndex)
    {
        _playerPosition[0] = playerPosition.x;
        _playerPosition[1] = playerPosition.y;
        _saveSlotIndex = saveSlotIndex;
        _sceneIndex = sceneIndex;
    }
}