#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DebugConsole : MonoBehaviour
{
	[SerializeField] private EventSystem _eventSystem = default;
	[SerializeField] private GameObject _startingMenu = default;
	[SerializeField] private Selectable _startingOption = default;
	private PlayerInput _playerInputSystem;
	private GameObject _currentMenu;
	private GameObject _previousMenu;
	private bool _isDebugConsoleOpen;


	void Start()
	{
		_currentMenu = _startingMenu;
		GameObject player = GameManager.Instance.GetPlayer();
		if (player != null)
		{
			_playerInputSystem = player.GetComponent<PlayerInput>();
			if (_startingMenu.activeSelf)
			{
				_playerInputSystem.enabled = false;
			}
			else
			{
				_playerInputSystem.enabled = true;
			}
		}
	}

	public void SetDebugMenuAction(bool state)
	{
		if (_playerInputSystem != null)
		{
			_playerInputSystem.enabled = !_playerInputSystem.isActiveAndEnabled;
		}
		if (state && !_isDebugConsoleOpen)
		{
			_isDebugConsoleOpen = true;
			_startingMenu.SetActive(true);
			_startingOption.Select();
		}
		else if (_isDebugConsoleOpen)
		{
			if (_startingMenu.activeSelf)
			{
				_isDebugConsoleOpen = false;
				_startingMenu.SetActive(false);
			}
			else
			{
				GoBackMenu();
			}
		}
	}

	private void GoBackMenu()
	{
		_currentMenu.SetActive(false);
		_previousMenu.SetActive(true);
		_currentMenu = _previousMenu;
		_startingOption.Select();
	}

	public void OpenMenu(GameObject newMenu)
	{
		_eventSystem.SetSelectedGameObject(null);
		_startingMenu.SetActive(false);
		newMenu.SetActive(true);

		_previousMenu = _currentMenu;
		_currentMenu = newMenu;
	}
}
#endif