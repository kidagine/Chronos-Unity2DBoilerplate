using System.Collections;
using UnityEngine;

public class TargetDummy : MonoBehaviour, IHurtboxResponder
{
	[SerializeField] private EntityAudio _targetDummyAudio = default;
	[SerializeField] private SpriteRenderer _spriteRenderer = default;
	private bool _isRecovered = true;

	public void TakeDamage(int damage, Vector2 knockbackDirection = default, float knockbackForce = 0)
	{
		if (_isRecovered)
		{
			_targetDummyAudio.Play("Hurt");
			StartCoroutine(FlashRedCoroutine());
		}

	}

	IEnumerator FlashRedCoroutine()
	{
		_isRecovered = false;
		_spriteRenderer.color = Color.red;
		yield return new WaitForSeconds(0.25f);
		_spriteRenderer.color = Color.white;
		_isRecovered = true;
	}
}
