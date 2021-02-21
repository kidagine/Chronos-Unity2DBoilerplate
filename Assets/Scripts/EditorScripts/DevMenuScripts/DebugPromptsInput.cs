#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
    
public class DebugPromptsInput : MonoBehaviour
{
    [SerializeField] private UnityEvent _backUnityEvent = default;
    private DebugInputActions _debugInputActions = default;
    

    void Awake()
    {
        PromptInputSetup();
    }

    private void PromptInputSetup()
    {
        _debugInputActions = new DebugInputActions();
        _debugInputActions.Prompts.Back.performed += Back;
    }

    private void Back(InputAction.CallbackContext context)
    {
        _backUnityEvent?.Invoke();
    }

    void OnEnable()
    {
        _debugInputActions.Enable();
    }

    void OnDisable()
    {
        _debugInputActions.Disable();
    }
}
#endif