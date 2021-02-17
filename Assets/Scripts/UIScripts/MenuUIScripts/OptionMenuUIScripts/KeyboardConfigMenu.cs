using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Audio))]
public class KeyboardConfigMenu : BaseMenu
{
	[SerializeField] private DeviceConfigurator _deviceConfigurator = default;
	[SerializeField] private ControlsMenu _controlsMenu = default;
	[SerializeField] private RemapButton[] _remapButtons = default;
	private readonly string _controlMatch = "<Keyboard>";
	private readonly string _controlCancel = "<Keyboard>/escape";
	private Audio _audio;


	void Awake()
	{
		_audio = GetComponent<Audio>();
	}

	public void RemapInput(RemapButton remapButton)
	{
		_controlsMenu.RemapInput(remapButton, _controlMatch, _controlCancel);
	}

	public void ResetRemapSettings()
	{
		_audio.Sound("Reset").Play();
		foreach (RemapButton remapButton in _remapButtons)
		{
			InputAction inputAction = remapButton.InputActionReference.action;
			InputActionRebindingExtensions.RemoveAllBindingOverrides(inputAction);
		}
		_controlsMenu.SaveKeyboardPreferences();
		UpdateAllRemapButtons();
	}

	public void InitializePreferences()
	{
		PlayerInput player = InputManager.Instance.GetPlayerInput();
		string rebinds = PlayerPrefs.GetString("keyboardRebinds");
		player.actions.LoadBindingOverridesFromJson(rebinds);
		UpdateAllRemapButtons();
	}

	public void UpdateAllRemapButtons()
	{
		foreach (RemapButton remapButton in _remapButtons)
		{
			InputAction inputAction = remapButton.InputActionReference.action;
			string currentBindingInput = InputControlPath.ToHumanReadableString(inputAction.bindings[remapButton.CompositeIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
			remapButton.PromptImage.sprite = _deviceConfigurator.GetDeviceBindingIcon(InputManager.Instance.GetPlayerInput(), currentBindingInput);
		}
	}
}