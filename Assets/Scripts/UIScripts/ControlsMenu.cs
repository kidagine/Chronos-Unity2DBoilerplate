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
		string controlsPath;
		if (remapButton.IsControllerRemap)
		{
			controlsPath = "<Gamepad>";
		}
		else
		{
			controlsPath = "<Keyboard>";
		}
		_rebindingOperation = remapButton.InputActionReference.action.PerformInteractiveRebinding().WithControlsHavingToMatchPath(controlsPath)
			.WithControlsExcluding("<Keyboard>/escape")
			.WithControlsExcluding("<Gamepad>/Start")
			.OnMatchWaitForAnother(0.1f).OnComplete(
			operation => RemapComplete(remapButton)).Start();
	}

	private void RemapComplete(RemapButton remapButton)
	{
		_rebindingOperation.Dispose();
		InputManager.Instance.ActivatePlayerInput();

		InputAction focusedInputAction = InputManager.Instance.GetPlayerInputAction("Space");
		int controlBindingIndex = focusedInputAction.GetBindingIndexForControl(focusedInputAction.controls[0]);
		string currentBindingInput = InputControlPath.ToHumanReadableString(focusedInputAction.bindings[controlBindingIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
		remapButton.PromptImage.sprite = _deviceConfigurator.GetDeviceBindingIcon(InputManager.Instance.GetPlayerInput(), currentBindingInput);
		
		remapButton.SetLock(false);
	}
}