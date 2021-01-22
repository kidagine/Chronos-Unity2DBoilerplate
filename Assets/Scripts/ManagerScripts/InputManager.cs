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
}
