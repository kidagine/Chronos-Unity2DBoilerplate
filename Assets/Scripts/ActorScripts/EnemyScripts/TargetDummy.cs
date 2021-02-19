using System.Collections;
using UnityEngine;

public class TargetDummy : MonoBehaviour, IHurtboxResponder
{
	[SerializeField] private Audio _targetDummyAudio = default;
	[SerializeField] private SpriteRenderer _spriteRenderer = default;
	[SerializeField] private Rigidbody2D _rigidbody = default;
	private bool _isRecovered = true;


	public void TakeDamage(int damage, Vector2 knockbackDirection = default, float knockbackForce = 0)
	{
		if (_isRecovered)
		{
			_targetDummyAudio.Sound("Hurt").Play();
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
