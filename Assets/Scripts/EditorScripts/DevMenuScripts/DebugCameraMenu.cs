using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DebugCameraMenu : MonoBehaviour
{
	[SerializeField] private Selectable _startingOption = default;
    [SerializeField] private TextMeshProUGUI _debugCameraText = default;
    [SerializeField] private Camera _debugCamera = default;
    [SerializeField] private EventSystem _eventSystem = default;
    [SerializeField] private GameObject _debugCameraTitle = default;
    [SerializeField] private DebugCameraInput _debugCameraInput = default;
    [SerializeField] private DebugInputSystem _debugInputSystem = default;

    private void OnEnable()
	{
		_startingOption.Select();
	}

    public void ToggleDebugCamera(bool state)
    {
        if (state)
        {
            _debugCamera.depth = 100;
            _debugCameraTitle.SetActive(true);
            _eventSystem.sendNavigationEvents = false;
            _debugInputSystem.enabled = false;
            _debugCameraInput.enabled = true;
            _debugCameraText.text = "On";
        }
        else
        {
            _debugCamera.depth = -100;
            _debugCameraTitle.SetActive(false);
            _eventSystem.sendNavigationEvents = true;
            _debugInputSystem.enabled = true;
            _debugCameraInput.enabled = false;
            _debugCameraText.text = "Off";
        }
    }
}
