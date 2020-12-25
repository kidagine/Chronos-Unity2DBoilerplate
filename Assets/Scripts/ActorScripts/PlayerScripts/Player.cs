﻿using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IHurtboxResponder
{
	[SerializeField] private PlayerAnimator _playerAnimator = default;
	[SerializeField] private PlayerMovement _playerMovement = default;
	[SerializeField] private PlayerUI _playerUI = default;
	[SerializeField] private EntityAudio _playerAudio = default;
	[SerializeField] private Rigidbody2D _rigidbody = default;
	[SerializeField] private SpriteRenderer _spriteRenderer = default;
	[SerializeField] private int _maxHealth = 3;
	private bool _recovered = true;
	private int _health;

	public bool IsFlipped { get; private set; }


	void Awake()
	{
		_health = _maxHealth;
		_playerUI.PlayerStatsUI.SetMaxHealth(_maxHealth);
	}

	#region Actions - Methods invoked by the input system  
	public void AttackAction()
	{
		if (_playerMovement.IsGrounded)
		{
			if (_playerMovement.IsCrouched)
			{
				_playerAnimator.CrouchAttackAnimation();
			}
			else
			{
				_playerAnimator.AttackAnimation();
			}
		}
		else
		{
			_playerAnimator.AttackAnimation();
		}
	}


	public void MenuAction()
	{
		_playerUI.PlayerPauseMenuUI.TogglePauseMenu();
	}
	#endregion

	public void TakeDamage(int damage, Vector2 knockbackDirection, float knockbackForce)
	{
		if (_recovered)
		{
			_recovered = false;
			_health--;
			_playerMovement.IsStunned = true;
			Knockback(knockbackDirection, knockbackForce);
			_playerAudio.Play("Hurt");
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

	public void FlipSide()
	{
		IsFlipped = !IsFlipped;
		transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y); 
	}

	IEnumerator FlashRedCoroutine()
	{
		_spriteRenderer.color = Color.red;
		_playerUI.PlayerStatsUI.SetHealth(_health);
		yield return new WaitForSeconds(0.25f);
		_playerMovement.IsStunned = false;
		_recovered = true;
		_spriteRenderer.color = Color.white;
	}

	private void Knockback(Vector2 knockbackDirection, float knockbackForce)
	{
		_rigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
	}

}