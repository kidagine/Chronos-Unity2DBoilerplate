using UnityEngine;

[RequireComponent(typeof(Audio))]
[RequireComponent(typeof(Animator))]
public class VideoMenu : BaseMenu, IOptionMenu
{
    [SerializeField] private BaseSelector _screenModeSelector = default;
    [SerializeField] private BaseSelector _resolutionSelector = default;
    [SerializeField] private BaseToggle _vSyncToggle = default;
    private Audio _audio;
    private Animator _animator;

    void Awake()
    {
        _audio = GetComponent<Audio>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
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
        Vector2 resolution = GetResolutionVector(value);
        Screen.SetResolution((int)resolution.x, (int)resolution.y, Screen.fullScreenMode);
    }

    public Vector2 GetResolutionVector(int value)
    {
        switch (value)
        {
            case 0:
                return new Vector2(800, 600);
            case 1:
                return new Vector2(1024, 768);
            case 2:
                return new Vector2(1280, 720);
            case 3:
                return new Vector2(1360, 760);
            case 4:
                return new Vector2(1600, 900);
            case 5:
                return new Vector2(1920, 1080);
            case 6:
                return new Vector2(2560, 1440);
            default:
                return new Vector2(800, 600);
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
        _animator.SetTrigger("PopUp");
        PreferenceInitializer.Instance.SetScreenMode(_screenModeSelector.GetValue());
        PreferenceInitializer.Instance.SetResolution(GetResolutionVector(_resolutionSelector.GetValue()));
        PreferenceInitializer.Instance.SetVSync(_vSyncToggle.GetValue());
    }

    public void ResetSettings()
    {
        _audio.Sound("Reset").Play();
        _animator.SetTrigger("PopDown");
        _screenModeSelector.SetValue(PreferenceInitializer.Instance.DefaultScreenMode);
        _resolutionSelector.SetValue(GetResolutionIndex((int)PreferenceInitializer.Instance.DefaultResolution.x));
        _vSyncToggle.SetValue(PreferenceInitializer.Instance.DefaultVSync);
    }

    void OnDisable()
    {
        InitializePreferences();
    }
}
