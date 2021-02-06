using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RemapButton : BaseButton
{
	[SerializeField] private Button _button = default;
	[SerializeField] private Image _promptImage = default;
	[SerializeField] private InputActionReference _inputActionReference = default;

	public Image PromptImage { get { return _promptImage; } set { } }
	public InputActionReference InputActionReference { get { return _inputActionReference; } set { } }


	public void SetLock(bool state)
	{
		_entityAudio.Sound("Pressed").Play();
		if (state)
		{
			_animator.SetBool("IsClicked", true);
			Navigation navigation = new Navigation() { mode = Navigation.Mode.None };
			_button.navigation = navigation;
		}
		else
		{
			_animator.SetBool("IsClicked", false);
			Navigation navigation = new Navigation() { mode = Navigation.Mode.Automatic };
			_button.navigation = navigation;
		}

	}
}
