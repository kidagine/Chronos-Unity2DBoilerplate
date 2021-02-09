using UnityEngine;

public class SaveMenu : BaseMenu
{
	[SerializeField] private SaveSlot[] _saveSlots = default;


	void OnEnable()
	{
		SetSaveSlotsInformation();	
	}

	private void SetSaveSlotsInformation()
	{
		for (int i = 0; i < _saveSlots.Length; i++)
		{
			SaveData saveData = SaveManager.Instance.GetSave(i + 1);
			if (saveData != null)
			{
				_saveSlots[i].SetSaveSlotInformation(saveData.saveSlotName, saveData.saveSlotDate);
			}
			else
			{
				_saveSlots[i].SetSaveSlotToNew();
			}
		}
	}

	public void LoadSave(int saveSlot)
	{
		SaveManager.Instance.Load(saveSlot);
	}

	public void DeleteSave(int saveSlot)
	{
		SaveManager.Instance.Delete(saveSlot);
	}
}
