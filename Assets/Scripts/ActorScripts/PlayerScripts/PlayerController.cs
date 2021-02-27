using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInteract))]
public class PlayerController : MonoBehaviour
{
    private Player _player;
    private PlayerMovement _playerMovement;
    private PlayerInteract _playerInteract;
    private PlayerUI _playerUI;
    private PlayerInput _playerInput;
    private PlayerInputActions _playerInputActions;
    private readonly string _gameplayActionMap = "Gameplay";
    private readonly string _dialogueActionMap = "Dialogue";


    void Awake()
    {
        _player = GetComponent<Player>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInteract = GetComponent<PlayerInteract>();
        _playerUI = GetComponent<PlayerUI>();
        _playerInput = GetComponent<PlayerInput>();
        PlayerInputSetup();
    }

	void Start()
	{
        _playerInputActions.Dialogue.Disable();
    }

    private void PlayerInputSetup()
    {
        _playerInputActions = new PlayerInputActions();
    }

    public void SetMove(InputAction.CallbackContext context)
    {
        if (context.performed)
            _playerMovement.MovementInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
            _playerMovement.JumpAction();
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
            _player.AttackAction();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
            _playerInteract.InteractAction();
    }

    public void Menu(InputAction.CallbackContext context)
    {
        if (context.performed)
            _player.MenuAction();
    }

    public void NextDialogue(InputAction.CallbackContext context)
    {
        if (context.performed)
            _playerUI.PlayerDialogueUI.MarkLineComplete();
    }

    public void SwitchToDialogueActionMap()
    {
        _playerInput.SwitchCurrentActionMap(_dialogueActionMap);
        _playerMovement.MovementInput = Vector2.zero;
    }

    public void SwitchToGameplayActionMap()
    {
        _playerInput.SwitchCurrentActionMap(_gameplayActionMap);
        _playerMovement.MovementInput = Vector2.zero;
    }

    public void DeviceLost(PlayerInput playerInput)
    {
        _player.MenuAction();
    }

    public void ActivateInput()
    {
        _playerInput.ActivateInput();
    }

    public void DeactivateInput() 
    {
        _playerInput.DeactivateInput();
        _playerMovement.MovementInput = Vector2.zero;
    }
}
