using UnityEngine;

public class PreferenceInitializer : MonoBehaviour
{
    [SerializeField] private VideoMenu _videoMenu = default;
    [SerializeField] private AudioMenu _audioMenu = default;
    

    void Awake()
    {
        _videoMenu.InitializePreferences();
        _audioMenu.InitializePreferences();
    }
}
