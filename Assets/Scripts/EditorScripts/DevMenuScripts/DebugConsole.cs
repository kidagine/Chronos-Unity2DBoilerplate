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
		PlayerController playerController = null;
		if (player != null)
		{
			playerController = player.GetComponent<PlayerController>();
		}

		if (state && !_devMenu.activeSelf)
		{
			_devMenu.SetActive(true);
			if (playerController != null)
			{
				playerController.DeactivateInput();
			}
		}
		else if (_devMenu.activeSelf)
		{
			_devMenu.SetActive(false);
			_eventSystem.SetSelectedGameObject(null);
			if (playerController != null)
			{
				playerController.ActivateInput();
			}
		}
	}
}
#endif