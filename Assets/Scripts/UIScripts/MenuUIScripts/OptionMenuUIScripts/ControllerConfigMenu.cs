using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class ControllerConfigMenu : BaseMenu
{
	[SerializeField] private ControlsMenu _controlsMenu = default;
	[SerializeField] private RemapButton[] _remapButtons = default;
	private readonly string _controlMatch = "<Gamepad>";
	private readonly string _controlCancel = "<Keyboard>/escape";
	private readonly string _controlRebindKey = "controllerRebinds";
	private Animator _animator;


	void Awake()
	{
		_animator = GetComponent<Animator>();
		InitializePreferences();
	}

	public void RemapInput(RemapButton remapButton)
	{
		_controlsMenu.RemapInput(remapButton, _controlRebindKey, _controlMatch, _controlCancel);
	}

	public void ResetRemapSettings()
	{
		_animator.SetTrigger("PopDown");
		_controlsMenu.ResetRemapSettings(_remapButtons, _controlRebindKey);
	}

	public void InitializePreferences()
	{
		PlayerInput player = InputManager.Instance.GetPlayerInput();
		string rebinds = PlayerPrefs.GetString(_controlRebindKey);
		player.actions.LoadBindingOverridesFromJson(rebinds);
		_controlsMenu.UpdateAllRemapButtons(_remapButtons);
	}
}