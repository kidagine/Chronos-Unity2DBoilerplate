using UnityEngine;

public class ExitMenu : BaseMenu
{
	[SerializeField] private GameObject _exitBorder = default;
	[SerializeField] private GameObject _exitingGame = default;
	[SerializeField] private GameObject _exitPrompts = default;
	[SerializeField] private GameObject _sharedCanvas = default;


	public async void ExitGame()
	{
		_exitPrompts.SetActive(false);
		_exitBorder.SetActive(false);
		_sharedCanvas.SetActive(false);
		_exitingGame.SetActive(true);
		await UpdateTimer.WaitFor(1.0f);
		Application.Quit();
	}
}
