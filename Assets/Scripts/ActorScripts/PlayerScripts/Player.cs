using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IHurtboxResponder
{
	[SerializeField] private PlayerAnimator _playerAnimator = default;
	[SerializeField] private PlayerMovement _playerMovement = default;
	[SerializeField] private PlayerUI _playerUI = default;
	[SerializeField] private Audio _playerAudio = default;
	[SerializeField] private Rigidbody2D _rigidbody = default;
	[SerializeField] private SpriteRenderer _spriteRenderer = default;
	[SerializeField] private GameObject _hurtboxes = default;
	[SerializeField] private GameObject _pushboxes = default;
	[SerializeField] private PlayerStats _playerStats = default;

	public bool IsRecovered { get; private set; } = true;
	public bool IsAttacking { get; set; }


	void Awake()
	{
		_playerUI.PlayerStatsUI.SetMaxHealth(_playerStats.health);
		_playerUI.PlayerStatsUI.SetHealth(_playerStats.currentHealth);
	}

	public void AttackAction()
	{
		if (_playerMovement.IsGrounded && !IsAttacking)
		{
			IsAttacking = true;
			_playerAudio.Sound("Attack").Play();
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
			Knockback(knockbackDirection, knockbackForce);
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
		_spriteRenderer.color = Color.red;
		_playerUI.PlayerStatsUI.SetHealth(_playerStats.currentHealth);
		yield return new WaitForSeconds(0.25f);
		IsRecovered = true;
		_spriteRenderer.color = Color.white;
	}

	private void Knockback(Vector2 knockbackDirection, float knockbackForce)
	{
		_rigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
	}
}
