using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player = default;
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
		_playerInput.Controls.Attack.canceled += Attack;
        _playerInput.Controls.Menu.performed += Menu;
    }

    private void SetMove(InputAction.CallbackContext context)
    {
        _playerMovement.MovementInput = context.ReadValue<Vector2>();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        _playerMovement.JumpAction();
    }

    private void Attack(InputAction.CallbackContext context)
    {
        _player.AttackAction();
    }

    private void Menu(InputAction.CallbackContext context)
    {
        _player.MenuAction();
    }

    void OnEnable()
    {
        _playerInput.Enable();
    }

    void OnDisable()
    {
        _playerInput.Disable();
        _playerMovement.MovementInput = Vector2.zero;
    }
}
