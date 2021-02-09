#if UNITY_EDITOR

using TMPro;
using UnityEngine;

public class DebugStateMenu : BaseMenu
{
	[SerializeField] private TextMeshProUGUI _saveSlotText = default;
	private int _saveSlot = 1;


	public void SetSaveSlot(float saveSlot)
	{
		_saveSlot = (int)saveSlot;
		_saveSlotText.text = saveSlot.ToString();
	}

	public void Save()
	{
		SaveManager.Instance.Save(_saveSlot);
	}

	public void Load()
	{
		SaveManager.Instance.Load(_saveSlot);
	}
}
#endif