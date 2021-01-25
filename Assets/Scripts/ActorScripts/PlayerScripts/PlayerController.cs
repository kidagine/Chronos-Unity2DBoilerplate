using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player = default;
    [SerializeField] private PlayerMovement _playerMovement = default;
    [SerializeField] private PlayerInteract _playerInteract = default;
    [SerializeField] private DialogueUI _playerDialogue = default;
    private PlayerInputActions _playerInputActions;


    void Awake()
    {
        PlayerInputSetup();
    }

	void Start()
	{
        _playerInputActions.Dialogue.Disable();
    }

    private void PlayerInputSetup()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Gameplay.Movement.performed += SetMove;
        _playerInputActions.Gameplay.Jump.performed += Jump;
		_playerInputActions.Gameplay.Attack.performed += Attack;
        _playerInputActions.Gameplay.Interact.performed += Interact;
        _playerInputActions.Gameplay.Menu.performed += Menu;
        _playerInputActions.Dialogue.NextDialogue.performed += NextDialogue;
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

    public void NextDialogue(InputAction.CallbackContext context)
    {
        _playerDialogue.MarkLineComplete();
    }

    public void SwitchToDialogueActionMap()
    {
        _playerInputActions.Dialogue.Enable();
        _playerInputActions.Gameplay.Disable();
        _playerMovement.MovementInput = Vector2.zero;
    }

    public void SwitchToGameplayActionMap()
    {
        _playerInputActions.Gameplay.Enable();
        _playerInputActions.Dialogue.Disable();
        _playerMovement.MovementInput = Vector2.zero;
    }

    void OnEnable()
    {
        _playerInputActions.Enable();
    }

    void OnDisable()
    {
        _playerInputActions.Disable();
        _playerMovement.MovementInput = Vector2.zero;
    }
}
