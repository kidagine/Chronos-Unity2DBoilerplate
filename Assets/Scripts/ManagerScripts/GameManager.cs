using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private GameObject _player;
    public event Action OnPlayerFound;

    IEnumerator Start()
    {
        // Wait for the localization system to initialize, loading Locales, preloading etc.
        yield return LocalizationSettings.InitializationOperation;

        // Generate list of available Locales
        int selected = 0;
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales[i];
            Debug.Log(locale.name);
            if (LocalizationSettings.SelectedLocale == locale)
                selected = i;
        }
        LocaleSelected(1);
    }
    void OnEnable()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    static void LocaleSelected(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _player = player;
        }
		OnPlayerFound?.Invoke();
    }

    void OnDisable()
    {
    }

    public GameObject GetPlayer()
    {
        if (_player != null)
        {
            return _player;
        }
        else
        {
            return null;
        }
    }
}
