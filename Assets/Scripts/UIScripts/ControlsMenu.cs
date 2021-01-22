using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControlsMenu : MonoBehaviour, ISubMenu
{
	[SerializeField] private Selectable _startingOption = default;
	[SerializeField] private Image _someSprite = default;
	private InputActionRebindingExtensions.RebindingOperation _rebindingOperation;
	private Sprite[] _keyboardMousePromptSprites;
	private Sprite[] _playstationPromptSprites;


	void Start()
	{
		_keyboardMousePromptSprites = Resources.LoadAll<Sprite>("Sprites/KeyboardMousePrompts_SPR");
		_playstationPromptSprites = Resources.LoadAll<Sprite>("Sprites/PlaystationPrompts_SPR");
	}

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
		int bindingIndex = remapButton.InputActionReference.action.GetBindingIndexForControl(remapButton.InputActionReference.action.controls[0]);
		string name = InputControlPath.ToHumanReadableString(remapButton.InputActionReference.action.bindings[bindingIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
		if (remapButton.IsControllerRemap)
		{
			remapButton.PromptImage.sprite = GetPromptSpriteWithName(name, _playstationPromptSprites);
		}
		else
		{
			remapButton.PromptImage.sprite = GetPromptSpriteWithName(name, _keyboardMousePromptSprites);
		}
		remapButton.SetLock(false);
	}

	private Sprite GetPromptSpriteWithName(string name, Sprite[] promptSprites)
	{
		Sprite promptSprite = null;
		for (int i = 0; i < promptSprites.Length; i++)
		{
			if (promptSprites[i].name.Equals(name))
			{
				promptSprite = promptSprites[i];
			}
		}
		return promptSprite;
	}
}