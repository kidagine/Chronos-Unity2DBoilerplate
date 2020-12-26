#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.EventSystems;

public class DebugConsole : MonoBehaviour
{
	[SerializeField] private EventSystem _eventSystem = default;
	[SerializeField] private GameObject _debugMenu = default;
	[SerializeField] private GameObject _startingOption = default;
	private PlayerInput _playerInputSystem;
	private GameObject _currentMenu;
	private GameObject _previousMenu;
	private GameObject _previousActiveOption;
	private bool _isDebugConsoleOpen;


	void Start()
	{
		if (GameManager.Instance)
		{
			GameObject player = GameManager.Instance.GetPlayer();
			_playerInputSystem = player.GetComponent<PlayerInput>();
			if (_debugMenu.activeSelf)
			{
				_playerInputSystem.enabled = false;
			}
			else
			{
				_playerInputSystem.enabled = true;
			}
		}
		else
		{
			Printer.Log("No GameManager", duration: 20.0f);
		}
	}

	public void ToggleDebugMenu(bool state)
	{
		if (state && !_isDebugConsoleOpen)
		{
			if (_playerInputSystem != null)
				_playerInputSystem.enabled = false;
			_isDebugConsoleOpen = true;
			_debugMenu.SetActive(true);
			_eventSystem.SetSelectedGameObject(_startingOption);
		}
		else if (_isDebugConsoleOpen)
		{
			if (_debugMenu.activeSelf)
			{
				if (_playerInputSystem != null)
					_playerInputSystem.enabled = true;
				_isDebugConsoleOpen = false;
				_debugMenu.SetActive(false);
			}
			else
			{
				GoBackMenu();
			}
		}
	}

	private void GoBackMenu()
	{
		_eventSystem.SetSelectedGameObject(null);
		_currentMenu.SetActive(false);
		_previousMenu.SetActive(true);
		_eventSystem.SetSelectedGameObject(_previousActiveOption);
	}

	public void OpenMenu(GameObject newMenu, GameObject currentMenu, GameObject currentActiveOption, GameObject previousActiveOption)
	{
		currentMenu.SetActive(false);
		newMenu.SetActive(true);
		_eventSystem.SetSelectedGameObject(currentActiveOption);

		_currentMenu = newMenu;
		_previousMenu = currentMenu;
		_previousActiveOption = previousActiveOption;
	}
}
#endif