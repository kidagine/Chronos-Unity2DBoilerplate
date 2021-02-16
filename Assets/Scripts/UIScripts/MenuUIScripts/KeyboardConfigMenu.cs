using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardConfigMenu : BaseMenu
{
	[SerializeField] private DeviceConfigurator _deviceConfigurator = default;
	private InputActionRebindingExtensions.RebindingOperation _rebindingOperation;
	private Audio _audio;
	[SerializeField] private RemapButton[] _remapButtons = default;

	void Awake()
	{
		_audio = GetComponent<Audio>();
	}

	public void RemapInput(RemapButton remapButton)
	{
		InputManager.Instance.DisablePlayerInput();
		remapButton.SetLock(true);
		InputAction inputAction = remapButton.InputActionReference.action;
		_rebindingOperation = inputAction.PerformInteractiveRebinding(remapButton.CompositeIndex)
			.WithControlsHavingToMatchPath("<Keyboard>")
			.WithControlsExcluding("<Keyboard>/f1")
			.WithControlsExcluding("<Keyboard>/f2")
			.WithControlsExcluding("<Keyboard>/f3")
			.WithControlsExcluding("<Keyboard>/f4")
			.WithControlsExcluding("<Keyboard>/f5")
			.WithControlsExcluding("<Keyboard>/f6")
			.WithControlsExcluding("<Keyboard>/f7")
			.WithControlsExcluding("<Keyboard>/f8")
			.WithControlsExcluding("<Keyboard>/f9")
			.WithControlsExcluding("<Keyboard>/f10")
			.WithControlsExcluding("<Keyboard>/f11")
			.WithControlsExcluding("<Keyboard>/f12")
			.WithControlsExcluding("<Keyboard>/enter")
			.WithControlsExcluding("Any Key")
			.WithCancelingThrough("<Keyboard>/escape")
			.OnMatchWaitForAnother(0.1f)
			.OnComplete(operation => RemapComplete(remapButton))
			.OnCancel(operation => RemapCancelled(remapButton));

		_rebindingOperation.Start();
	}

	private void RemapComplete(RemapButton remapButton)
	{
		_rebindingOperation.Dispose();
		remapButton.SetLock(false);
		SaveKeyboardPreferences();
		UpdateRemapButton(remapButton);
	}

	private void RemapCancelled(RemapButton remapButton)
	{
		_rebindingOperation.Dispose();
		remapButton.SetLock(false);
	}

	private void UpdateRemapButton(RemapButton remapButton)
	{
		InputAction inputAction = remapButton.InputActionReference.action;
		string currentBindingInput = InputControlPath.ToHumanReadableString(inputAction.bindings[remapButton.CompositeIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
		remapButton.PromptImage.sprite = _deviceConfigurator.GetDeviceBindingIcon(InputManager.Instance.GetPlayerInput(), currentBindingInput);
	}

	public void SaveKeyboardPreferences()
	{
		PlayerInput player = InputManager.Instance.GetPlayerInput();
		string rebinds = player.actions.SaveBindingOverridesAsJson();
		PlayerPrefs.SetString("keyboardRebinds", rebinds);
	}

	public void ResetRemapSettings(RemapButton remapButton)
	{
		_audio.Sound("Reset").Play();
		InputAction inputAction = remapButton.InputActionReference.action;
		InputActionRebindingExtensions.RemoveAllBindingOverrides(inputAction);
		UpdateRemapButton(remapButton);
	}

	public void InitializePreferences()
	{
		PlayerInput player = InputManager.Instance.GetPlayerInput();
		string rebinds = PlayerPrefs.GetString("keyboardRebinds");
		player.actions.LoadBindingOverridesFromJson(rebinds);

		foreach (RemapButton remapButton in _remapButtons)
		{
			InputAction inputAction = remapButton.InputActionReference.action;
			string currentBindingInput = InputControlPath.ToHumanReadableString(inputAction.bindings[remapButton.CompositeIndex	].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
			remapButton.PromptImage.sprite = _deviceConfigurator.GetDeviceBindingIcon(InputManager.Instance.GetPlayerInput(), currentBindingInput);
		}
	}

	private bool RemapExists(RemapButton remapButton)
	{
		var bindingString = remapButton.InputActionReference.action.GetBindingDisplayString(InputBinding.MaskByGroup("Keyboard"));
		Debug.Log(bindingString);
		return true;
	}
}