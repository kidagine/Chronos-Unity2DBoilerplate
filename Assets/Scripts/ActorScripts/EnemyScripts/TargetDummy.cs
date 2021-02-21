using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Audio))]
public class TargetDummy : MonoBehaviour, IHurtboxResponder
{
	private Audio _audio;
	private Rigidbody2D _rigidbody;
	private SpriteRenderer _spriteRenderer;
	private bool _isRecovered = true;


	void Awake()
	{
		_audio = GetComponent<Audio>();
		_rigidbody = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void TakeDamage(int damage, Vector2 knockbackDirection = default, float knockbackForce = 0)
	{
		if (_isRecovered)
		{
			_audio.Sound("Hurt").Play();
			Knockback(knockbackDirection, knockbackForce);
			StartCoroutine(FlashRedCoroutine());
		}
	}

	IEnumerator FlashRedCoroutine()
	{
		_isRecovered = false;
		_spriteRenderer.color = Color.red;
		yield return new WaitForSeconds(0.25f);
		_rigidbody.velocity = new Vector2(0.0f, _rigidbody.velocity.y);
		_spriteRenderer.color = Color.white;
		_isRecovered = true;
	}

	private void Knockback(Vector2 knockbackDirection, float knockbackForce)
	{
		_rigidbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
		_rigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
	}
}
