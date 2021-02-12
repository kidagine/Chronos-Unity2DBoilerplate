using UnityEngine;

public class PreferenceInitializer : MonoBehaviour
{
    [SerializeField] private VideoMenu _videoMenu = default;
    [SerializeField] private AudioMenu _audioMenu = default;
    [SerializeField] private KeyboardConfigMenu _keyboardConfigMenu = default;
    [SerializeField] private ControllerConfigMenu _controllerConfigMenu = default;


    void Start()
    {
        _videoMenu.InitializePreferences();
        _audioMenu.InitializePreferences();
        _keyboardConfigMenu.InitializePreferences();
        _controllerConfigMenu.InitializePreferences();
    }
}
