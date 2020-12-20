using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement = default;
    private PlayerInputActions _playerInput;


    void Awake()
    {
        PlayerInputSetup();
    }

    private void PlayerInputSetup()
    {
        _playerInput = new PlayerInputActions();
        _playerInput.Controls.Movement.performed += SetMove;
        _playerInput.Controls.Jump.performed += Jump;
        _playerInput.Controls.Crouch.performed += Crouch;
        _playerInput.Controls.Crouch.canceled += StandUp;
    }

    private void SetMove(InputAction.CallbackContext context)
    {
        _playerMovement.MovementInput = context.ReadValue<Vector2>();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        _playerMovement.JumpAction();
    }

    private void Crouch(InputAction.CallbackContext context)
    {
        _playerMovement.CrouchAction();
    }

    private void StandUp(InputAction.CallbackContext context)
    {
        _playerMovement.StandUpAction();
    }

    void OnEnable()
    {
        _playerInput.Enable();
    }

    void OnDisable()
    {
        _playerInput.Disable(); 
    }
}
