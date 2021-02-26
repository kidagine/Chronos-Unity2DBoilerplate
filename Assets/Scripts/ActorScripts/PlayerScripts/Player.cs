using UnityEngine;

[RequireComponent(typeof(Audio))]
[RequireComponent(typeof(PlayerUI))]
[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour, IHurtboxResponder
{
	[SerializeField] private PlayerAnimator _playerAnimator = default;
	[Header("Collision boxes")]
	[SerializeField] private GameObject _hurtboxes = default;
	[SerializeField] private GameObject _pushboxes = default;
	private Audio _audio;
	private PlayerUI _playerUI;
	private PlayerStats _playerStats;
	private PlayerMovement _playerMovement;

	public bool IsAttacking { get; set; }


	void Awake()
	{
		_audio = GetComponent<Audio>();
		_playerUI = GetComponent<PlayerUI>();
		_playerStats = GetComponent<PlayerStats>();
		_playerMovement = GetComponent<PlayerMovement>();
		_playerUI.PlayerStatsUI.SetMaxHealth(_playerStats.health);
		_playerUI.PlayerStatsUI.SetHealth(_playerStats.currentHealth);
	}

	public void AttackAction()
	{
		if (_playerMovement.IsGrounded && !IsAttacking)
		{
			IsAttacking = true;
			_audio.Sound("Attack").Play();
			_playerMovement.SetMovementLock(true);
			_playerAnimator.AttackAnimation();
		}
	}

	public void MenuAction()
	{
		_playerUI.PlayerPauseMenuUI.OpenPauseMenu();
	}

	public void TakeDamage(int damage, Vector2 knockbackDirection, float knockbackForce)
	{
		if (!_playerMovement.IsMovementLocked)
		{
			_playerStats.currentHealth--;
			_playerMovement.SetMovementLock(true);
			_playerMovement.Knockback(knockbackDirection, knockbackForce);
			_playerUI.PlayerStatsUI.SetHealth(_playerStats.currentHealth);
			if (_playerStats.currentHealth > 0)
			{
				_playerAnimator.HurtAnimation();
			}
			else
			{
				_playerAnimator.DeathAnimation();
			}
		}
	}
}
