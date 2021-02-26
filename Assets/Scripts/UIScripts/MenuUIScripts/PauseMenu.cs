using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : BaseMenu
{
	[SerializeField] private EventSystem _eventSystem = default;


	public void OpenPauseMenu()
	{
		gameObject.SetActive(true);
		GameManager.Instance.SetGamePauseState(true);
	}

	public void ClosePauseMenu()
	{
		gameObject.SetActive(false);
		_eventSystem.SetSelectedGameObject(null);
		GameManager.Instance.SetGamePauseState(false);
	}
}