using Steamworks;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IHurtboxResponder
{
	[SerializeField] private PlayerAnimator _playerAnimator = default;
	[SerializeField] private PlayerMovement _playerMovement = default;
	[SerializeField] private PlayerUI _playerUI = default;
	[SerializeField] private EntityAudio _playerAudio = default;
	[SerializeField] private Rigidbody2D _rigidbody = default;
	[SerializeField] private SpriteRenderer _spriteRenderer = default;
	[SerializeField] private GameObject _hurtboxes = default;
	[SerializeField] private GameObject _pushboxes = default;
	[SerializeField] private int _maxHealth = 3;
	private int _health;

	public bool IsRecovered { get; private set; } = true;
	public bool IsAttacking { get; set; }


	void Awake()
	{
		_health = _maxHealth;
		_playerUI.PlayerStatsUI.SetMaxHealth(_maxHealth);
	}

	void Update()
	{
		Debug.Log("a");
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log(SteamFriends.GetPersonaName() + "here");
			if (SteamManager.Initialized)
			{
				Debug.Log(SteamFriends.GetPersonaName() + " my name");
				SteamUserStats.SetAchievement("ACH_WIN_ONE_GAME");
				SteamUserStats.StoreStats();
			}
		}
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
			_health--;
			_playerMovement.SetMovementLock(true);
			Knockback(knockbackDirection, knockbackForce);
			if (_health > 0)
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
		_playerUI.PlayerStatsUI.SetHealth(_health);
		yield return new WaitForSeconds(0.25f);
		IsRecovered = true;
		_spriteRenderer.color = Color.white;
	}

	private void Knockback(Vector2 knockbackDirection, float knockbackForce)
	{
		_rigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
	}
}
