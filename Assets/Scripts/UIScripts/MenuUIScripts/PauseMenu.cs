using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : BaseMenu
{
	[SerializeField] private PlayerController _playerController = default;
	[SerializeField] private CursorHandler _cursorHandler = default;
	[SerializeField] private EventSystem _eventSystem = default;


	public void OpenPauseMenu()
	{
		gameObject.SetActive(true);
		_playerController.enabled = false;
		GameManager.Instance.SetGamePauseState(true);
	}

	public void ClosePauseMenu()
	{
		gameObject.SetActive(false);
		_eventSystem.SetSelectedGameObject(null);
		_playerController.enabled = true;
		GameManager.Instance.SetGamePauseState(false);
	}
}