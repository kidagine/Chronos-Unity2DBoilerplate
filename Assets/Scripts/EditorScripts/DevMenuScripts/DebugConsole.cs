#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DebugConsole : MonoBehaviour
{
	[SerializeField] private EventSystem _eventSystem = default;
	[SerializeField] private GameObject _startingMenu = default;
	[SerializeField] private Selectable _startingOption = default;
	private PlayerController _playerInputSystem;
	private GameObject _currentMenu;
	private GameObject _previousMenu;
	private bool _isDebugConsoleOpen;


	void OnEnable()
	{
		_currentMenu = _startingMenu;
	}

	public void SetDebugMenuAction(bool state)
	{
		GameObject player = GameManager.Instance.GetPlayer();
		if (player != null)
		{
			_playerInputSystem = player.GetComponent<PlayerController>();
		}
		if (state && !_isDebugConsoleOpen)
		{
			_isDebugConsoleOpen = true;
			_startingMenu.SetActive(true);
			_startingOption.Select();
			_playerInputSystem.enabled = false;
		}
		else if (_isDebugConsoleOpen)
		{
			if (_startingMenu.activeSelf)
			{
				_isDebugConsoleOpen = false;
				_startingMenu.SetActive(false);
				_playerInputSystem.enabled = true;
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
		_currentMenu = _previousMenu;
		_startingOption.Select();
	}

	public void OpenMenu(GameObject newMenu)
	{
		_eventSystem.SetSelectedGameObject(null);
		_startingMenu.SetActive(false);
		newMenu.SetActive(true);
		if (newMenu.TryGetComponent(out ISubMenu subMenu))
		{
			subMenu.Activate();
		}

		_previousMenu = _currentMenu;
		_currentMenu = newMenu;
		newMenu.SetActive(true);
	}
}
#endif