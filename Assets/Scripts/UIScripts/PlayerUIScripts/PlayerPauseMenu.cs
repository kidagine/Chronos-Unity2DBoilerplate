using UnityEngine;

public class PlayerPauseMenu : MonoBehaviour
{
	[SerializeField] private GameObject _pauseMenu = default;


	public void TogglePauseMenu()
	{
		_pauseMenu.SetActive(!_pauseMenu.activeSelf);
	}
}
