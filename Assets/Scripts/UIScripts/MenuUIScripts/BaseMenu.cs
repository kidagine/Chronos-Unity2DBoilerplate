using UnityEngine;
using UnityEngine.UI;

public class BaseMenu : MonoBehaviour, ISubMenu
{
	[SerializeField] private Selectable _startingOption = default;


	void OnEnable()
	{
		Activate();
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