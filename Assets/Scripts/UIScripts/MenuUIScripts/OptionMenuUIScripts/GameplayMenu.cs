using UnityEngine;
using UnityEngine.Localization.Settings;

[RequireComponent(typeof(Audio))]
public class GameplayMenu : BaseMenu, IOptionMenu
{
    [SerializeField] private BaseSelector _languageSelector = default;
    private Audio _audio;


    void Awake()
    {
        _audio = GetComponent<Audio>();
    }

    public void SetLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    public void InitializePreferences()
    {
        _languageSelector.SetValue(PlayerPrefs.GetInt("language", _languageSelector.DefaultValue));
    }

    public void ConfirmSettings()
    {
        _audio.Sound("Reset").Play();
        PlayerPrefs.SetInt("language", _languageSelector.GetValue());
    }

    public void ResetSettings()
    {
        _audio.Sound("Reset").Play();
        _languageSelector.ResetValue();
    }

    void OnDisable()
    {
        InitializePreferences();
    }
}
