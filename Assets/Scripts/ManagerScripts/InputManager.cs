using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput = default;
    public static InputManager Instance { get; private set; }
    private string _currentControlScheme;
    public event Action ControlsChanged;

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
            ControlsChanged?.Invoke();
            //playerVisualsBehaviour.UpdatePlayerVisuals();
        }
    }

    public InputAction GetInputAction(string actionName)
    {
        return _playerInput.actions.FindAction(actionName);
    }

    public PlayerInput GetPlayerInput()
    {
        return _playerInput;
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
