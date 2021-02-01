using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : BaseMenu
{
	[SerializeField] private PlayerController _playerController = default;
	[SerializeField] private EventSystem _eventSystem = default;


	public void OpenPauseMenu()
	{
		gameObject.SetActive(true);
		_playerController.enabled = false;
	}

	public void ClosePauseMenu()
	{
		gameObject.SetActive(false);
		_playerController.enabled = true;
		_eventSystem.SetSelectedGameObject(null);
	}
}