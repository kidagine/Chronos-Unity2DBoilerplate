using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Audio))]
[RequireComponent(typeof(PlayerUI))]
[RequireComponent(typeof(PlayerStats))]
public class Player : MonoBehaviour, IHurtboxResponder
{
	[SerializeField] private PlayerAnimator _playerAnimator;
	[SerializeField] private PlayerMovement _playerMovement = default;
	[SerializeField] private GameObject _hurtboxes = default;
	[SerializeField] private GameObject _pushboxes = default;
	private Audio _audio;
	private PlayerUI _playerUI;
	private PlayerStats _playerStats;

	public bool IsRecovered { get; private set; } = true;
	public bool IsAttacking { get; set; }


	void Awake()
	{
		_audio = GetComponent<Audio>();
		_playerUI = GetComponent<PlayerUI>();
		_playerStats = GetComponent<PlayerStats>();
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
		if (IsRecovered)
		{
			IsRecovered = false;
			_playerMovement.SetMovementLock(true);
			_playerStats.currentHealth--;
			_playerMovement.Knockback(knockbackDirection, knockbackForce);
			if (_playerStats.currentHealth > 0)
			{
				_playerAnimator.HurtAnimation();
			}
			else
			{
				_playerAnimator.DeathAnimation();
			}
			StartCoroutine(FlashRedCoroutine());
		}
	}

	IEnumerator FlashRedCoroutine()
	{
		_playerUI.PlayerStatsUI.SetHealth(_playerStats.currentHealth);
		yield return new WaitForSeconds(0.25f);
		IsRecovered = true;
	}
}
