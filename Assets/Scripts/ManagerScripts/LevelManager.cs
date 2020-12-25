using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private readonly string _sceneAppendix = "_SCN";


    public void GoToLevel(Levels levels)
    {
        SceneManager.LoadScene(levels.LevelsEnums + _sceneAppendix);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
