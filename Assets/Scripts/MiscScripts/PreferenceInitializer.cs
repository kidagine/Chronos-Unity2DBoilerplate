using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class PreferenceInitializer : MonoBehaviour
{
    [SerializeField] private GameplayMenu _gameplayMenu = default;
    [SerializeField] private VideoMenu _videoMenu = default;
    [SerializeField] private AudioMenu _audioMenu = default;
    [SerializeField] private KeyboardConfigMenu _keyboardConfigMenu = default;
    [SerializeField] private ControllerConfigMenu _controllerConfigMenu = default;


    IEnumerator Start()
    {
        yield return LocalizationSettings.InitializationOperation;

        _gameplayMenu.InitializePreferences();
        _videoMenu.InitializePreferences();
        _audioMenu.InitializePreferences();
        _keyboardConfigMenu.InitializePreferences();
        _controllerConfigMenu.InitializePreferences();
    }
}
