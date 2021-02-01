using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PromptsInput : MonoBehaviour
{
    [SerializeField] private PlayerInputActions _promptsInputActions = default;
    [SerializeField] private UnityEvent _confirmUnityEvent = default;
    [SerializeField] private UnityEvent _backUnityEvent = default;
    [SerializeField] private Image[] _promptImages = default;


    void Awake()
    {
        PromptInputSetup();
    }

	private void PromptInputSetup()
    {
        _promptsInputActions = new PlayerInputActions();
        _promptsInputActions.Prompts.Confirm.performed += Confirm;
        _promptsInputActions.Prompts.Back.performed += Back;
    }

    private void Confirm(InputAction.CallbackContext context)
    {
        _confirmUnityEvent?.Invoke();
    }

    private void Back(InputAction.CallbackContext context)
    {
        _backUnityEvent?.Invoke();
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
