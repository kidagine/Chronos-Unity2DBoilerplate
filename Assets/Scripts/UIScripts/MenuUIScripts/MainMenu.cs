using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour, ISubMenu
{
    [SerializeField] private Selectable _startingOption = default;


	void Awake()
	{
        GameManager.Instance.SetGamePauseState(true);
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
