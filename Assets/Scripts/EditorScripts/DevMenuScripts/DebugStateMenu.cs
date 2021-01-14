using UnityEngine;
using UnityEngine.UI;

public class DebugStateMenu : MonoBehaviour
{
	[SerializeField] private Selectable _startingOption = default;


	private void OnEnable()
	{
		_startingOption.Select();
	}

	public void Save()
	{
		SaveManager.Instance.Save();
	}

	public void Load()
	{
		SaveManager.Instance.Load();
	}
}
