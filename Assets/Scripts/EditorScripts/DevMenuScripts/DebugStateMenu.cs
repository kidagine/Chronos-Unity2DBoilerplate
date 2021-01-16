using UnityEngine;
using UnityEngine.UI;

public class DebugStateMenu : MonoBehaviour, ISubMenu
{
	[SerializeField] private Selectable _startingOption = default;


	public void Save()
	{
		SaveManager.Instance.Save();
	}

	public void Load()
	{
		SaveManager.Instance.Load();
	}

	public void NextCheckpoint()
	{
		CheckpointManager.Instance.GoToNextCheckpoint();
	}

	public void PreviousCheckpoint()
	{
		CheckpointManager.Instance.GoToPreviousCheckpoint();
	}

	public void Activate()
	{
		_startingOption.Select();
	}
}
