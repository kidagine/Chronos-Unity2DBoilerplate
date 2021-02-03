#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DebugPromptsInput : MonoBehaviour
{
    [SerializeField] private DebugInputActions _debugInputActions = default;
    [SerializeField] private UnityEvent _backUnityEvent = default;
    [SerializeField] private Image[] _promptImages = default;


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