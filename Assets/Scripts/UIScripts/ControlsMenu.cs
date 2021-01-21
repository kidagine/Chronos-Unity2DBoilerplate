using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControlsMenu : MonoBehaviour, ISubMenu
{
	[SerializeField] private Selectable _startingOption = default;
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

	public void RemapInput(InputActionReference inputActionReference)
	{
		_rebindingOperation = inputActionReference.action.PerformInteractiveRebinding().OnMatchWaitForAnother(0.1f).OnComplete(
			operation => RemapComplete(inputActionReference)).Start();
	}

	private void RemapComplete(InputActionReference inputActionReference)
	{
		_rebindingOperation.Dispose();
		int bindingIndex = inputActionReference.action.GetBindingIndexForControl(inputActionReference.action.controls[0]);
		Object promptObject = Resources.Load("Sprites/UISprites/PlaystationPrompts_SPR/PlaystationPrompts_SPR_0");
		Sprite promptSprite = (Sprite) promptObject;
		Debug.Log(InputControlPath.ToHumanReadableString(inputActionReference.action.bindings[bindingIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice));
	}
}