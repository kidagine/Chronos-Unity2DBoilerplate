using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class PreferenceInitializer : MonoBehaviour
{
    [SerializeField] private bool _initializeMenues = default;
    [SerializeField] private GameplayMenu _gameplayMenu = default;
    [SerializeField] private VideoMenu _videoMenu = default;
    [SerializeField] private AudioMenu _audioMenu = default;
    [SerializeField] private KeyboardConfigMenu _keyboardConfigMenu = default;
    [SerializeField] private ControllerConfigMenu _controllerConfigMenu = default;


    IEnumerator Start()
    {
        if (_initializeMenues)
        {
            _videoMenu.InitializePreferences();
            _audioMenu.InitializePreferences();
            _keyboardConfigMenu.InitializePreferences();
            _controllerConfigMenu.InitializePreferences();
            yield return LocalizationSettings.InitializationOperation;
            _gameplayMenu.InitializePreferences();
        }
        else
        {
            //Sound
            //SoundManager.Instance.SetMusic();
            //SoundManager.Instance.SetMusic();
            //SoundManager.Instance.SetMusic();
            //Video

            //Gameplay
        }
    }
}
