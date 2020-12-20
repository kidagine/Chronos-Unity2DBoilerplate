using UnityEngine;

public class SwordPokeAttack : MonoBehaviour, IHitboxResponder
{
	public void HitboxCollided(RaycastHit2D hit, Hurtbox hurtbox)
	{
		Debug.Log("damage");
		hurtbox.TakeDamage(1);
	}
}
