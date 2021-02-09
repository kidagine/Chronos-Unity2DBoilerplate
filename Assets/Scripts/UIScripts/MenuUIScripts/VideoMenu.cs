﻿using UnityEngine;
using UnityEngine.UI;

public class VideoMenu : MonoBehaviour, ISubMenu
{
	[SerializeField] private Selectable _startingOption = default;
    [SerializeField] private BaseSelector _screenModeSelector = default;
    [SerializeField] private BaseSelector _resolutionSelector = default;
    [SerializeField] private BaseToggle _vSyncToggle = default;
    private EntityAudio _audio;


    void Awake()
    {
        _audio = GetComponent<EntityAudio>();
    }

    public void OpenMenu(GameObject menu)
	{
		gameObject.SetActive(false);
		if (menu.TryGetComponent(out ISubMenu subMenu))
		{
			subMenu.Activate();
		}
	}

	public void Activate()
	{
		gameObject.SetActive(true);
		_startingOption.Select();
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

    public void ResetVideoSettings()
    {
        _audio.Sound("Reset").Play();
        _screenModeSelector.ResetValue();
        _resolutionSelector.ResetValue();
        _vSyncToggle.ToggleOff();
    }
}