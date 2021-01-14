using UnityEngine;

public class Damager : MonoBehaviour, IHitboxResponder
{
	[SerializeField] private int _damage = 1;
	[SerializeField] private Vector2 _knockbackDirection = default;
	[SerializeField] private float _knockbackForce = default;
	[SerializeField] private GameObject _hitEffectPrefab = default;


	public void HitboxCollided(RaycastHit2D hit, Hurtbox hurtbox)
	{
		GameObject hitEffect = Instantiate(_hitEffectPrefab, hit.point, Quaternion.identity);
		hitEffect.transform.up = hit.normal;
		Vector2 hitEffectDirection = hit.transform.root.position - transform.root.position;
		if (hitEffectDirection.x > 0.0f)
		{
			hurtbox.TakeDamage(_damage, _knockbackDirection, _knockbackForce);
		}
		else
		{
			hurtbox.TakeDamage(_damage, new Vector2(_knockbackDirection.x * -1.0f, _knockbackDirection.y), _knockbackForce);
		}
	}
}
