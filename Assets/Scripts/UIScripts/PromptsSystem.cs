using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PromptsSystem : MonoBehaviour
{
    [SerializeField] private PromptsInputActions _promptsInputActions = default;
    [SerializeField] private UnityEvent _confirmUnityEvent = default;


    void Awake()
    {
        PromptInputSetup();
    }

    private void PromptInputSetup()
    {
        _promptsInputActions = new PromptsInputActions();
        _promptsInputActions.Controls.Confirm.performed += Confirm;
    }

    private void Confirm(InputAction.CallbackContext context)
    {
        _confirmUnityEvent.Invoke();
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
