using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerConfigMenu : BaseMenu
{
	[SerializeField] private DeviceConfigurator _deviceConfigurator = default;
	private InputActionRebindingExtensions.RebindingOperation _rebindingOperation;
	private EntityAudio _audio;


	void Awake()
	{
		_audio = GetComponent<EntityAudio>();
	}

	public void RemapInput(RemapButton remapButton)
	{
		InputManager.Instance.DisablePlayerInput();
		remapButton.SetLock(true);
		InputAction focusedInputAction = remapButton.InputActionReference.action;
		_rebindingOperation = focusedInputAction.PerformInteractiveRebinding()
			.WithControlsHavingToMatchPath("<Gamepad>")
			.WithCancelingThrough("<Keyboard>/escape")
			.OnMatchWaitForAnother(0.1f)
			.OnComplete(operation => RemapComplete(remapButton))
			.OnCancel(operation => RemapCancelled(remapButton));

		_rebindingOperation.Start();
	}

	private void RemapComplete(RemapButton remapButton)
	{
		_rebindingOperation.Dispose();
		InputAction focusedInputAction = remapButton.InputActionReference.action;
		int controlBindingIndex = focusedInputAction.GetBindingIndexForControl(focusedInputAction.controls[0]);
		string currentBindingInput = InputControlPath.ToHumanReadableString(focusedInputAction.bindings[controlBindingIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
		RemapExists(remapButton);
		SaveControllerPreferences();
		Debug.Log(remapButton.InputActionReference.action.GetBindingDisplayString());
		remapButton.PromptImage.sprite = _deviceConfigurator.GetDeviceBindingIcon(InputManager.Instance.GetPlayerInput(), currentBindingInput);
		remapButton.SetLock(false);
	}

	private void RemapCancelled(RemapButton remapButton)
	{
		_rebindingOperation.Dispose();
		remapButton.SetLock(false);
	}

	public void SaveControllerPreferences()
	{
		PlayerInput player = InputManager.Instance.GetPlayerInput();
		string rebinds = player.actions.SaveBindingOverridesAsJson();
		PlayerPrefs.SetString("controllerRebinds", rebinds);
	}

	public void InitializePreferences()
	{
		PlayerInput player = InputManager.Instance.GetPlayerInput();
		string rebinds = PlayerPrefs.GetString("controllerRebinds");
		player.actions.LoadBindingOverridesFromJson(rebinds);
	}

	public void ResetRemapSettings(RemapButton remapButton)
	{
		_audio.Sound("Reset").Play();
		//InputAction focusedInputAction = InputManager.Instance.GetPlayerInputAction("Jump");
		//InputActionRebindingExtensions.RemoveAllBindingOverrides(focusedInputAction);
		//UpdateRemapButton(remapButton);
	}

	private bool RemapExists(RemapButton remapButton)
	{
		Debug.Log(remapButton.InputActionReference.action.GetBindingDisplayString());
		return true;
	}
}