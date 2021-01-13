using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugPlayerMenu : MonoBehaviour
{
	[SerializeField] private Selectable _startingOption = default;
	[SerializeField] private TextMeshProUGUI _invicibilityText = default;


	private void OnEnable()
	{
		_startingOption.Select();
	}

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
}
