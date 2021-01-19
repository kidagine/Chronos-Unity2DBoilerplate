using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PromptsInput : MonoBehaviour
{
    [SerializeField] private PromptsInputActions _promptsInputActions = default;
    [SerializeField] private UnityEvent _confirmUnityEvent = default;
    [SerializeField] private UnityEvent _backUnityEvent = default;


    void Awake()
    {
        PromptInputSetup();
    }

    private void PromptInputSetup()
    {
        _promptsInputActions = new PromptsInputActions();
        _promptsInputActions.Controls.Confirm.performed += Confirm;
        _promptsInputActions.Controls.Back.performed += Back;
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
