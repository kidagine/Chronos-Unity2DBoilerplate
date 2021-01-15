using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugPlayerMenu : MonoBehaviour, ISubMenu
{
	[SerializeField] private Selectable _startingOption = default;
	[SerializeField] private TextMeshProUGUI _invicibilityText = default;


	public void SetInvicibility(bool state)
	{
		if (state)
		{
			_invicibilityText.text = "On";
		}
		else
		{
			_invicibilityText.text = "Off";
		}
	}

	public void Activate()
	{
		_startingOption.Select();
	}
}
