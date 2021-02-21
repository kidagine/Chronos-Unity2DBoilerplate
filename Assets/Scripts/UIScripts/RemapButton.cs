using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RemapButton : BaseButton
{
	[SerializeField] private Image _promptImage = default;
	[SerializeField] private InputActionReference _inputActionReference = default;
	[SerializeField] private bool _isComposite = default;
	[ConditionalHide("_isComposite", true)]
	[SerializeField] private int _compositeIndex = default;

	public Image PromptImage { get { return _promptImage; } set { } }
	public InputActionReference InputActionReference { get { return _inputActionReference; } set { } }
	public int CompositeIndex { get { return _compositeIndex; } set { } }
	public bool IsComposite { get { return _isComposite; } set { } }


	public void SetLock(bool state)
	{
		_audio.Sound("Pressed").Play();
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
