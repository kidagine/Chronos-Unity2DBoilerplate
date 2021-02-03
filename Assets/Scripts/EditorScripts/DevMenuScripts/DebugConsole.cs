#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.EventSystems;

public class DebugConsole : MonoBehaviour
{
	[SerializeField] private EventSystem _eventSystem = default;
	[SerializeField] private GameObject _devMenu = default;


	public void SetDebugMenuAction(bool state)
	{
		GameObject player = GameManager.Instance.GetPlayer();
		PlayerController playerInputSystem = null;
		if (player != null)
		{
			playerInputSystem = player.GetComponent<PlayerController>();
		}

		if (state && !_devMenu.activeSelf)
		{
			_devMenu.SetActive(true);
			if (playerInputSystem != null)
			{
				playerInputSystem.enabled = false;
			}
		}
		else if (_devMenu.activeSelf)
		{
			_devMenu.SetActive(false);
			_eventSystem.SetSelectedGameObject(null);
			if (playerInputSystem != null)
			{
				playerInputSystem.enabled = true;
			}
		}
	}
}
#endif