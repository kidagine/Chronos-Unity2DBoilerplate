using System;
using UnityEngine;

[RequireComponent(typeof(Audio))]
public class VideoMenu : BaseMenu, IOptionMenu
{
    [SerializeField] private BaseSelector _screenModeSelector = default;
    [SerializeField] private BaseSelector _resolutionSelector = default;
    [SerializeField] private BaseToggle _vSyncToggle = default;
    private Audio _audio;


    void Awake()
    {
        _audio = GetComponent<Audio>();
        InitializePreferences();
    }

    public void SetScreenMode(int value)
    {
        switch (value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
        }
    }

    public void SetResolution(int value)
    {
        switch (value)
        {
            case 0:
                Screen.SetResolution(800, 600, Screen.fullScreenMode);
                break;
            case 1:
                Screen.SetResolution(1024, 768, Screen.fullScreenMode);
                break;
            case 2:
                Screen.SetResolution(1280, 720, Screen.fullScreenMode);
                break;
            case 3:
                Screen.SetResolution(1360, 768, Screen.fullScreenMode);
                break;
            case 4:
                Screen.SetResolution(1600, 900, Screen.fullScreenMode);
                break;
            case 5:
                Screen.SetResolution(1920, 1080, Screen.fullScreenMode);
                break;
            case 6:
                Screen.SetResolution(2560, 1440, Screen.fullScreenMode);
                break;
        }
    }


    public int GetResolutionIndex(int value)
    {
        switch (value)
        {
            case 800:
                return 0;
            case 1024:
                return 1;
            case 1280:
                return 2;
            case 1360:
                return 3;
            case 1600:
                return 4;
            case 1920:
                return 4;
            case 2560:
                return 5;
            default:
                return 0;
        }
    }

    public void SetVSync(bool isOn)
	{
		if (isOn)
		{
			QualitySettings.vSyncCount = 1;
		}
		else
		{
            QualitySettings.vSyncCount = 0;
		}
	}

    public void InitializePreferences()
    {
        _screenModeSelector.SetValue(PreferenceInitializer.Instance.ScreenMode);
        _resolutionSelector.SetValue(GetResolutionIndex((int)PreferenceInitializer.Instance.Resolution.x));
        _vSyncToggle.SetValue(PreferenceInitializer.Instance.VSync);
    }

    public void ConfirmSettings()
    {
        _audio.Sound("Confirm").Play();
        PreferenceInitializer.Instance.SetScreenMode(_screenModeSelector.GetValue());
        PreferenceInitializer.Instance.SetResolution(_resolutionSelector.GetValue());
        PreferenceInitializer.Instance.SetVSync(_vSyncToggle.GetValue());
    }

    public void ResetSettings()
    {
        _audio.Sound("Reset").Play();
        _screenModeSelector.SetValue(PreferenceInitializer.Instance.DefaultScreenMode);
        _resolutionSelector.SetValue(GetResolutionIndex((int)PreferenceInitializer.Instance.DefaultResolution.x));
        _vSyncToggle.SetValue(PreferenceInitializer.Instance.DefaultVSync);
    }

    void OnDisable()
    {
        InitializePreferences();
    }
}
