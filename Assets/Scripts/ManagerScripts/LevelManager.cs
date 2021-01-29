using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private SceneTransitions _sceneTransitions = default;
    private readonly string _sceneAppendix = "_SCN";
    private Levels _cachedLevel;

    public event Action OnAdditiveSceneLoaded;


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

    public void GoToLevel(int levelIndex)
    {
        if (!_sceneTransitions)
        {
            SceneManager.LoadScene(levelIndex);
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

    public void AddAdditiveScene(Levels levels)
    {
        StartCoroutine(AddAdditiveSceneCoroutine(levels));
    }

    IEnumerator AddAdditiveSceneCoroutine(Levels levels)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levels.LevelsEnums + _sceneAppendix, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        OnAdditiveSceneLoaded?.Invoke();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
