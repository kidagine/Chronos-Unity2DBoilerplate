#if UNITY_EDITOR
using UnityEngine.InputSystem;
using UnityEngine;

public class DebugInputSystem : MonoBehaviour
{
    [SerializeField] private DebugConsole _debugConsole = default;
    private DebugInputActions _debugInput;


    void Awake()
    {
        DebugInputSetup();
    }

    private void DebugInputSetup()
    {
        _debugInput = new DebugInputActions();
        _debugInput.DebugControls.ToggleDebugMenu.performed += OpenDebug;
    }

    private void OpenDebug(InputAction.CallbackContext context)
    {
        _debugConsole.SetDebugMenuAction(true);
    }

    void OnEnable()
    {
        _debugInput.Enable();
    }

    void OnDisable()
    {
        _debugInput.Disable();
    }
}
#endif