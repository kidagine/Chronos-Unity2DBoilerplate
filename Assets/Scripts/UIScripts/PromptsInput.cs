using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PromptsInput : MonoBehaviour
{
    [SerializeField] private PlayerInputActions _promptsInputActions = default;
    [SerializeField] private UnityEvent _confirmUnityEvent = default;
    [SerializeField] private UnityEvent _backUnityEvent = default;
    [SerializeField] private UnityEvent _mainSpecialUnityEvent = default;
    [SerializeField] private UnityEvent _secondarySpecialUnityEvent = default;


    void Awake()
    {
        PromptInputSetup();
    }

	private void PromptInputSetup()
    {
        _promptsInputActions = new PlayerInputActions();
        _promptsInputActions.Prompts.Confirm.performed += Confirm;
        _promptsInputActions.Prompts.Back.performed += Back;
        _promptsInputActions.Prompts.MainSpecial.performed += MainSpecial;
        _promptsInputActions.Prompts.SecondarySpecial.performed += SecondarySpecial;
    }

    private void Confirm(InputAction.CallbackContext context)
    {
        _confirmUnityEvent?.Invoke();
    }

    public void Confirm()
    {
        _confirmUnityEvent?.Invoke();
    }

	private void Back(InputAction.CallbackContext context)
	{
		_backUnityEvent?.Invoke();
	}

    public void Back()
    {
        _backUnityEvent?.Invoke();
    }

    private void MainSpecial(InputAction.CallbackContext context)
    {
        _mainSpecialUnityEvent?.Invoke();
    }

    public void MainSpecial()
    {
        _mainSpecialUnityEvent?.Invoke();
    }

    private void SecondarySpecial(InputAction.CallbackContext context)
    {
        _secondarySpecialUnityEvent?.Invoke();
    }

    public void SecondarySpecial()
    {
        _secondarySpecialUnityEvent?.Invoke();
    }

    void OnEnable()
    {
        _promptsInputActions.Enable();
    }

    void OnDisable()
    {
        _promptsInputActions.Disable();
    }
}
