using UnityEngine;

[RequireComponent(typeof(Level))]
public class ExitChoiceMenu : BaseMenu
{
    private Level _level;


	void Awake()
	{
        _level = GetComponent<Level>();
	}

	public void ExitToMainMenu()
    {
        LevelManager.Instance.GoToLevel(_level);
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }
}
