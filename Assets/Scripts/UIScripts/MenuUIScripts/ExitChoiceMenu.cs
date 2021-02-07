using UnityEngine;

public class ExitChoiceMenu : BaseMenu
{
    [SerializeField] private Levels _levels = default;


    public void ExitToMainMenu()
    {
        LevelManager.Instance.GoToLevel(_levels);
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }
}
