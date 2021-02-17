using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class PreferenceInitializer : Singleton<PreferenceInitializer>
{
    [Header("Gameplay")]
    [SerializeField] private int _defaultLanguageIndex = 1;
    [Header("Video")]
    [Range(0, 2)]
    [SerializeField] private int _defaultScreenMode = 0;
    [SerializeField] private bool _defaultVSync = false;
    [Header("Audio")]
    [Range(0.01f, 1.0f)]
    [SerializeField] private float _defaultMusicVolume = 1.0f;
    [Range(0.01f, 1.0f)]
    [SerializeField] private float _defaultVFXVolume = 1.0f;
    [Range(0.01f, 1.0f)]
    [SerializeField] private float _defaultUIVolume = 1.0f;

    public float DefaultMusicVolume { get { return _defaultMusicVolume; } private set { } }
    public float DefaultVFXVolume { get { return _defaultVFXVolume; } private set { } }
    public float DefaultUIVolume { get { return _defaultUIVolume; } private set { } }
    public int DefaultScreenMode { get { return _defaultScreenMode; } private set { } }
    public Vector2 DefaultResolution { get { return Vector2.zero; } private set { } }
    public bool DefaultVSync { get { return _defaultVSync; } private set { } }
    public int DefaultLanguageIndex { get { return _defaultLanguageIndex; } private set { } }

    public float MusicVolume { get; private set; }
    public float VFXVolume { get; private set; }
    public float UIVolume { get; private set; }
    public int ScreenMode { get; private set; }
    public Vector2 Resolution { get; private set; }
    public bool VSync { get; private set; }
    public int LanguageIndex { get; private set; }


    IEnumerator Start()
    {
        LanguageIndex = PlayerPrefs.GetInt("language", DefaultLanguageIndex);

        ScreenMode = PlayerPrefs.GetInt("screenMode", DefaultScreenMode);
        Resolution = new Vector2(PlayerPrefs.GetFloat("resolutionX", Screen.currentResolution.width), PlayerPrefs.GetFloat("resolutionY", Screen.currentResolution.height));
        VSync = Convert.ToBoolean(PlayerPrefs.GetInt("vSync", Convert.ToInt32(DefaultVSync)));

        MusicVolume = PlayerPrefs.GetFloat("musicVolume", DefaultMusicVolume);
        VFXVolume = PlayerPrefs.GetFloat("vfxVolume", DefaultVFXVolume);
        UIVolume = PlayerPrefs.GetFloat("uiVolume", DefaultUIVolume);

        //Sound
        SoundManager.Instance.SetMusicVolume(MusicVolume);
        SoundManager.Instance.SetVFXVolume(VFXVolume);
        SoundManager.Instance.SetUIVolume(UIVolume);
        //Video
        Screen.fullScreenMode = (FullScreenMode)ScreenMode;
        Screen.SetResolution((int)Resolution.x, (int)Resolution.y, Screen.fullScreenMode);
        QualitySettings.vSyncCount = Convert.ToInt32(VSync);
        //Gameplay
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[LanguageIndex];
    }

    public void SetLanguage(int value)
    {
        //PlayerPrefs.SetInt("language", value);
        //LanguageIndex = value;
    }

    public void SetScreenMode(int value)
    {
        PlayerPrefs.SetInt("screenMode", value);
        ScreenMode = value;
    }

    public void SetResolution(float value)
    {
        PlayerPrefs.SetFloat("resolutionX", value);
        PlayerPrefs.SetFloat("resolutionY", value);
        //Resolution = value;
    }

    public void SetVSync(bool value)
    {
        PlayerPrefs.SetInt("vSync", Convert.ToInt32(value));
        VSync = value;
    }

    public void SetMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("musicVolume", value);
        MusicVolume = value;
    }

    public void SetVFXVolume(float value)
    {
        PlayerPrefs.SetFloat("vfxVolume", value);
        VFXVolume = value;
    }

    public void SetUIVolume(float value)
    {
        PlayerPrefs.SetFloat("uiVolume", value);
        UIVolume = value;
    }
}
