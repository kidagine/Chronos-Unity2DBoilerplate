using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement = default;


    public void PlayerDiedAnimationEvent()
    {
        LevelManager.Instance.RestartLevel();
    }

    public void PlayerLockMovementAnimationEvent()
    {
        _playerMovement.SetMovementLock(true);
    }

    public void PlayerUnlockMovementAnimationEvent()
    {
        _playerMovement.SetMovementLock(false);
    }
}
