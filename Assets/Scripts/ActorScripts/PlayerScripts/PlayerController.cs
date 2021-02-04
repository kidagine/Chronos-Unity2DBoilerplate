using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player = default;
    [SerializeField] private PlayerMovement _playerMovement = default;
    [SerializeField] private PlayerInteract _playerInteract = default;
    [SerializeField] private DialogueUI _playerDialogue = default;
    private PlayerInput _playerInput;
    private readonly string _gameplayActionMap = "Gameplay";
    private readonly string _dialogueActionMap = "Dialogue";
    private static PlayerInputActions _playerInputActions;


    void Awake()
    {
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

    public static PlayerInputActions Tezo()
    {
        return _playerInputActions;
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
            _playerDialogue.MarkLineComplete();
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
