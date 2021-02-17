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
        InitializePreferences();
    }

    public void SetLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    public void InitializePreferences()
    {
        _languageSelector.SetValue(PreferenceInitializer.Instance.LanguageIndex);
    }

    public void ConfirmSettings()
    {
        _audio.Sound("Confirm").Play();
        PreferenceInitializer.Instance.SetLanguage(_languageSelector.GetValue());
    }

    public void ResetSettings()
    {
        _audio.Sound("Reset").Play();
        _languageSelector.SetValue(PreferenceInitializer.Instance.DefaultLanguageIndex);
    }

    void OnDisable()
    {
        InitializePreferences();
    }
}
