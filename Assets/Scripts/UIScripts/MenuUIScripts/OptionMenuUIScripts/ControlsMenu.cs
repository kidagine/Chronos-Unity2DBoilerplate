using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Audio))]
[RequireComponent(typeof(Animator))]
public class ControlsMenu : BaseMenu
{
	[SerializeField] private DeviceConfigurator _deviceConfigurator = default;
	[SerializeField] private CursorHandler _cursorHandler = default;
	private InputActionRebindingExtensions.RebindingOperation _rebindingOperation;
	private Audio _audio;
	private Animator _animator;


	void Awake()
	{
		_audio = GetComponent<Audio>();
		_animator = GetComponent<Animator>();
	}

	void Start()
	{
		//InitializePreferences();
	}

	public void RemapInput(RemapButton remapButton, string rebindKey, string controlMatch, string controlCancel, string[] controlsExcluding = default)
	{
		InputManager.Instance.DisablePlayerInput();
		remapButton.SetLock(true);
		_cursorHandler.SetCursorVisibility(false);
		InputAction inputAction = remapButton.InputActionReference.action;
		_rebindingOperation = inputAction.PerformInteractiveRebinding(remapButton.CompositeIndex)
			.WithControlsHavingToMatchPath(controlMatch)
			.WithCancelingThrough(controlCancel)
			.OnMatchWaitForAnother(0.1f)
			.OnComplete(operation => RemapComplete(remapButton, rebindKey))
			.OnCancel(operation => RemapCancelled(remapButton));

		_rebindingOperation.Start();
	}

	public void RemapComplete(RemapButton remapButton, string rebindKey)
	{
		_rebindingOperation.Dispose();
		remapButton.SetLock(false);
		_cursorHandler.SetCursorVisibility(true);
		SavePreferences(rebindKey);
		UpdateRemapButton(remapButton);
	}

	public void RemapCancelled(RemapButton remapButton)
	{
		_rebindingOperation.Dispose();
		remapButton.SetLock(false);
		_cursorHandler.SetCursorVisibility(true);
	}

	public void ResetRemapSettings(RemapButton[] remapButtons, string rebindKey)
	{
		_audio.Sound("Reset").Play();
		_animator.SetTrigger("PopUp");
		foreach (RemapButton remapButton in remapButtons)
		{
			InputAction inputAction = remapButton.InputActionReference.action;
			InputActionRebindingExtensions.RemoveAllBindingOverrides(inputAction);
		}
		SavePreferences(rebindKey);
		UpdateAllRemapButtons(remapButtons);
	}

	private void UpdateRemapButton(RemapButton remapButton)
	{
		InputAction inputAction = remapButton.InputActionReference.action;
		string currentBindingInput = InputControlPath.ToHumanReadableString(inputAction.bindings[remapButton.CompositeIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
		remapButton.PromptImage.sprite = _deviceConfigurator.GetDeviceBindingIcon(InputManager.Instance.GetPlayerInput(), currentBindingInput);
	}

	public void UpdateAllRemapButtons(RemapButton[] remapButtons)
	{
		foreach (RemapButton remapButton in remapButtons)
		{
			InputAction inputAction = remapButton.InputActionReference.action;
			string currentBindingInput = InputControlPath.ToHumanReadableString(inputAction.bindings[remapButton.CompositeIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
			remapButton.PromptImage.sprite = _deviceConfigurator.GetDeviceBindingIcon(InputManager.Instance.GetPlayerInput(), currentBindingInput);
		}
	}

	public void SavePreferences(string rebindKey)
	{
		PlayerInput player = InputManager.Instance.GetPlayerInput();
		string rebinds = player.actions.SaveBindingOverridesAsJson();
		PlayerPrefs.SetString(rebindKey, rebinds);
	}
}
