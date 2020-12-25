using UnityEngine;

public class PlayerPauseMenu : MonoBehaviour
{
	[SerializeField] private GameObject _pauseMenu = default;


	public void TogglePauseMenu()
	{
		Printer.Log("menu");
		_pauseMenu.SetActive(!_pauseMenu.activeSelf);
	}
}
