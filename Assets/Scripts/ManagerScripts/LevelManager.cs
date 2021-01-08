using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private SceneTransitions _sceneTransitions = default;
    private readonly string _sceneAppendix = "_SCN";
    private Levels _cachedLevel;


    public void GoToLevel(Levels levels)
    {
        if (!_sceneTransitions)
        {
            SceneManager.LoadScene(levels.LevelsEnums + _sceneAppendix);
        }
        else
        {
            _cachedLevel = levels;
            _sceneTransitions.FadeIn();
        }
    }

    public void GoToCachedLevel()
    {
        if (_cachedLevel != null)
        {
            SoundManager.Instance.SetMasterVolumeToCached();
            SceneManager.LoadScene(_cachedLevel.LevelsEnums + _sceneAppendix);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
