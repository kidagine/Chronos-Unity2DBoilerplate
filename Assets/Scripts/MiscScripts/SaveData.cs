using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    public string saveSlotName;
    public string saveSlotDate;
    public int saveSlotTimePlayed;
    public Vector2 playerPosition;
    public int playerCurrentHealth;
    public int saveSlotIndex;
    public int levelIndex;
}