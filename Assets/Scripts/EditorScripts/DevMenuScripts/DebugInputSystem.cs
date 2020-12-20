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
        _debugInput.DebugControls.OpenDebug.performed += OpenDebug;
        _debugInput.DebugControls.Cancel.performed += Cancel;
    }

    private void OpenDebug(InputAction.CallbackContext context)
    {
        _debugConsole.ToggleDebugMenu(true);
    }

    private void Cancel(InputAction.CallbackContext context)
    {
        _debugConsole.ToggleDebugMenu(false);
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
