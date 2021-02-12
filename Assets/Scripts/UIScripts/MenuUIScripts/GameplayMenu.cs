using UnityEngine;
using UnityEngine.Localization.Settings;

[RequireComponent(typeof(EntityAudio))]
public class GameplayMenu : BaseMenu
{
    [SerializeField] private BaseSelector _languageSelector = default;
    private EntityAudio _audio;


    void Awake()
    {
        _audio = GetComponent<EntityAudio>();
    }

    public void SetLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    public void InitializePreferences()
    {
        _languageSelector.SetValue(PlayerPrefs.GetInt("language", _languageSelector.DefaultValue));
    }

    public void ConfirmGameSettings()
    {
        _audio.Sound("Reset").Play();
        PlayerPrefs.SetInt("language", _languageSelector.GetValue());
    }

    public void ResetGameSettings()
    {
        _audio.Sound("Reset").Play();
        _languageSelector.ResetValue();
    }
}
