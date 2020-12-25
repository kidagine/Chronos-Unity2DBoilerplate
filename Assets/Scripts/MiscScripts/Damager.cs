using UnityEngine;

public class Damager : MonoBehaviour, IHitboxResponder
{
	[SerializeField] private int _damage = 1;
	[SerializeField] private Vector2 _knockbackDirection = default;
	[SerializeField] private float _knockbackForce = default;
	[SerializeField] private GameObject _hitEffectPrefab = default;


	public void HitboxCollided(RaycastHit2D hit, Hurtbox hurtbox)
	{
		Instantiate(_hitEffectPrefab, hit.transform.position, Quaternion.identity);
		hurtbox.TakeDamage(1, _knockbackDirection, _knockbackForce);
	}
}
