using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput = default;
    [SerializeField] private PlayerInput _promptsInput = default;
    public static InputManager Instance { get; private set; }
    private string _currentControlScheme;
    public event Action<bool> ControlsChanged;

    void Awake()
    {
        CheckInstance();
        OnControlChanged();
    }

    private void CheckInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void OnControlChanged()
    {
        if (_playerInput.currentControlScheme != _currentControlScheme)
        {
            _currentControlScheme = _playerInput.currentControlScheme;
            if (_currentControlScheme.Equals("Keyboard&Mouse"))
            {
                ControlsChanged?.Invoke(false);
            }
            else
            {
                ControlsChanged?.Invoke(true);
            }
        }
    }

    public InputAction GetPromptInputAction(string actionName)
    {
        InputAction inputAction = _promptsInput.actions.FindAction(actionName);
        if (inputAction == null)
        {
            Debug.LogError($"Could not find InputAction with name: {actionName} on PlayerInput: {_promptsInput.name}");
        }
        return _promptsInput.actions.FindAction(actionName);
    }

    public InputAction GetPlayerInputAction(string actionName)
    {
        return _playerInput.actions.FindAction(actionName);
    }

    public PlayerInput GetPlayerInput()
    {
        return _playerInput;
    }

    public PlayerInput GetPromptInput()
    {
        return _promptsInput;
    }

    public void ActivatePlayerInput()
    {
        _playerInput.ActivateInput();
    }

    public void DisablePlayerInput()
    {
        _playerInput.DeactivateInput();
    }
}
