using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IHurtboxResponder
{
	[SerializeField] private PlayerAnimator _playerAnimator = default;
	[SerializeField] private PlayerUI _playerUI = default;
	[SerializeField] private EntityAudio _playerAudio = default;
	[SerializeField] private SpriteRenderer _spriteRenderer = default;
	[SerializeField] private int _maxHealth = 3;
	private bool _recovered = true;
	private int _health;


	void Awake()
	{
		_health = _maxHealth;
		_playerUI.PlayerStatsUI.SetMaxHealth(_maxHealth);
	}

	public void AttackAction()
	{
		_playerAnimator.AttackAnimation();
	}

	public void TakeDamage(int damage)
	{
		if (_recovered)
		{
			_recovered = false;
			_health--;
			_playerAudio.Play("Hurt");
			Printer.Log($"Hurt{damage}");
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
		yield return new WaitForSeconds(0.5f);
		_recovered = true;
		_spriteRenderer.color = Color.white;
	}
}
