﻿using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField] private Player _player = default;
    [SerializeField] private PlayerMovement _playerMovement = default;
    [SerializeField] private EntityAudio _playerAudio = default;
    [SerializeField] private GameObject _smokeStopRunningPrefab = default;


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
        _player.IsAttacking = false;
        _playerMovement.SetMovementLock(false);
    }

    public void PlayerFootstepAnimationEvent()
    {
        _playerAudio.SoundGroup("Footsteps").PlayInRandom();
    }

    public void PlayerStopRunningSmokeEffectAnimationEvent()
    {
        Instantiate(_smokeStopRunningPrefab, transform.position, Quaternion.identity);
    }
}
