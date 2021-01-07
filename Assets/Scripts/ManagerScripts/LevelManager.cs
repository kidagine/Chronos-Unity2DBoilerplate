using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private SceneTransitions _sceneTransitions = default;
    private readonly string _sceneAppendix = "_SCN";


    public void GoToLevel(Levels levels)
    {
        if (!_sceneTransitions)
        {
            SceneManager.LoadScene(levels.LevelsEnums + _sceneAppendix);
        }
        _sceneTransitions.FadeIn();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
