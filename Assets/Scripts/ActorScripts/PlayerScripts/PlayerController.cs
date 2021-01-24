using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player = default;
    [SerializeField] private PlayerMovement _playerMovement = default;
    [SerializeField] private PlayerInteract _playerInteract = default;
    private PlayerInputActions _playerInput;


    void Awake()
    {
        PlayerInputSetup();
    }

    private void PlayerInputSetup()
    {
        _playerInput = new PlayerInputActions();
        _playerInput.Gameplay.Movement.performed += SetMove;
        _playerInput.Gameplay.Jump.performed += Jump;
		_playerInput.Gameplay.Attack.performed += Attack;
        _playerInput.Gameplay.Interact.performed += Interact;
        _playerInput.Gameplay.Menu.performed += Menu;
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

    private void Interact(InputAction.CallbackContext context)
    {
        _playerInteract.InteractAction();
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
