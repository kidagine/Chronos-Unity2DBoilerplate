using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControlsMenu : MonoBehaviour, ISubMenu
{
	[SerializeField] private Selectable _startingOption = default;
	[SerializeField] private DeviceConfigurator _deviceConfigurator = default;
	private InputActionRebindingExtensions.RebindingOperation _rebindingOperation;


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

	public void RemapInput(RemapButton remapButton)
	{
		InputManager.Instance.DisablePlayerInput();
		remapButton.SetLock(true);
		InputAction focusedInputAction = remapButton.InputActionReference.action;
		_rebindingOperation = focusedInputAction.PerformInteractiveRebinding()
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
		InputAction focusedInputAction = remapButton.InputActionReference.action;  
		int controlBindingIndex = focusedInputAction.GetBindingIndexForControl(focusedInputAction.controls[0]);
		string currentBindingInput = InputControlPath.ToHumanReadableString(focusedInputAction.bindings[controlBindingIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
		RemapExists(remapButton);
		remapButton.PromptImage.sprite = _deviceConfigurator.GetDeviceBindingIcon(InputManager.Instance.GetPlayerInput(), currentBindingInput);
		remapButton.SetLock(false);
	}

	private void RemapCancelled(RemapButton remapButton)
	{
		_rebindingOperation.Dispose();
		remapButton.SetLock(false);
	}

	private bool RemapExists(RemapButton remapButton)
	{
		var bindingString = remapButton.InputActionReference.action.GetBindingDisplayString(InputBinding.MaskByGroup("Keyboard"));
		Debug.Log(bindingString);
		return true;
	}
}