using UnityEngine;

public class CreditsMenu : MonoBehaviour, ISubMenu
{
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
    }
}
