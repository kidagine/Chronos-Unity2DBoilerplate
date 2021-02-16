using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsMenu : BaseMenu
{
	[SerializeField] private DeviceConfigurator _deviceConfigurator = default;
	private InputActionRebindingExtensions.RebindingOperation _rebindingOperation;


	public void RemapInput(RemapButton remapButton, string controlMatch, string controlCancel, string[] controlsExcluding = default)
	{
		InputManager.Instance.DisablePlayerInput();
		remapButton.SetLock(true);
		InputAction inputAction = remapButton.InputActionReference.action;
		_rebindingOperation = inputAction.PerformInteractiveRebinding(remapButton.CompositeIndex)
			.WithControlsHavingToMatchPath(controlMatch)
			.WithCancelingThrough(controlCancel)
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


	private void UpdateRemapButton(RemapButton remapButton)
	{
		InputAction inputAction = remapButton.InputActionReference.action;
		string currentBindingInput = InputControlPath.ToHumanReadableString(inputAction.bindings[remapButton.CompositeIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
		remapButton.PromptImage.sprite = _deviceConfigurator.GetDeviceBindingIcon(InputManager.Instance.GetPlayerInput(), currentBindingInput);
	}

	private void SaveKeyboardPreferences()
	{
		PlayerInput player = InputManager.Instance.GetPlayerInput();
		string rebinds = player.actions.SaveBindingOverridesAsJson();
		PlayerPrefs.SetString("keyboardRebinds", rebinds);
	}

	private void RemapCancelled(RemapButton remapButton)
	{
		_rebindingOperation.Dispose();
		remapButton.SetLock(false);
	}
}
