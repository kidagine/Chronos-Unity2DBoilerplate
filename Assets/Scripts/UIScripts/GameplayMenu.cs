using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

[RequireComponent(typeof(EntityAudio))]
public class GameplayMenu : MonoBehaviour, ISubMenu
{
    [SerializeField] private Selectable _startingOption = default;
    [SerializeField] private BaseSelector _languageSelector = default;
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

    public void SetLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    public void ResetGameSettings()
    {
        _audio.Sound("Reset").Play();
        _languageSelector.ResetValue();
    }
}
