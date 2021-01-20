using UnityEngine;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour, ISubMenu
{
	[SerializeField] private GameObject _exitBorder = default;
	[SerializeField] private GameObject _exitingGame = default;
	[SerializeField] private GameObject _exitPrompts = default;
	[SerializeField] private GameObject _sharedCanvas = default;
	[SerializeField] private Selectable _startingOption = default;


	public async void ExitGame()
	{
		_exitPrompts.SetActive(false);
		_exitBorder.SetActive(false);
		_sharedCanvas.SetActive(false);
		_exitingGame.SetActive(true);
		await UpdateTimer.WaitFor(1.0f);
		Application.Quit();
	}

	public void OpenMenu(GameObject menu)
	{
		gameObject.SetActive(false);
		if (menu.TryGetComponent(out ISubMenu subMenu))
		{
			subMenu.Activate();
		}
	}

	public void Activate()
	{
		gameObject.SetActive(true);
		_startingOption.Select();
	}
}
