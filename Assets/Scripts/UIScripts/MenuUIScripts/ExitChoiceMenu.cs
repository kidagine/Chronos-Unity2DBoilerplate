using UnityEngine;

public class ExitChoiceMenu : BaseMenu
{
    [SerializeField] private Level _levels = default;


    public void ExitToMainMenu()
    {
        LevelManager.Instance.GoToLevel(_levels);
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }
}
