using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private SceneTransitions _sceneTransitions = default;
    private readonly string _sceneAppendix = "_SCN";
    private Level _cachedLevel;

    public event Action OnAdditiveSceneLoaded;


    public void GoToLevel(Level levels)
    {
        if (!_sceneTransitions)
        {
            SceneManager.LoadScene(levels.LevelsEnum + _sceneAppendix);
        }
        else
        {
            _cachedLevel = levels;
            _sceneTransitions.FadeIn();
            _sceneTransitions.OnFadeIn += GoToCachedLevel;
        }
    }

    public void GoToCachedLevel()
    {
        if (_cachedLevel != null)
        {
            SoundManager.Instance.SetMasterVolumeToCached();
            SceneManager.LoadScene(_cachedLevel.LevelsEnum + _sceneAppendix);
        }
    }

    public void GoToLevel(int levelIndex)
    {
        if (!_sceneTransitions)
        {
            SceneManager.LoadScene(levelIndex);
        }
    }


    public void AddAdditiveLevel(Level levels)
    {
        StartCoroutine(AddAdditiveSceneCoroutine(levels));
    }

    IEnumerator AddAdditiveSceneCoroutine(Level levels)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levels.LevelsEnum + _sceneAppendix, LoadSceneMode.Additive);
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

    public int GetCurrentLevelIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public string GetCurrentLevelName()
    {
        string levelName = Regex.Replace(SceneManager.GetActiveScene().name, "([a-z])([A-Z])", "$1 $2");
        int index = levelName.IndexOf("_");
        return levelName.Substring(0, index);
    }

	void OnDestroy()
	{
        if (_sceneTransitions)
        {
            _sceneTransitions.OnFadeIn -= GoToCachedLevel;
        }
    }
}
