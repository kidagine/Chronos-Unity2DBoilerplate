﻿#if UNITY_EDITOR
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Hurtbox : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider = default;
    [SerializeField] private bool _damageable = true;
    [ConditionalHide("_damageable", true)]
    [SerializeField] private GameObject _hurtboxResponderObject = default;
    private Color _hitboxDamageableColor = Color.green;
    private Color _hitboxNonDamageableColor = Color.green;
    private IHurtboxResponder _hurtboxResponder;


    void Awake()
	{
        if (_damageable)
            _hurtboxResponder = _hurtboxResponderObject.GetComponent<IHurtboxResponder>();
	}

    public void TakeDamage(int damage, Vector2 knockbackDirection = default, float knockbackForce = default)
    {
        if (_damageable)
            _hurtboxResponder.TakeDamage(damage, knockbackDirection, knockbackForce);
    }

	private void OnDrawGizmos()
    {
        if (_boxCollider.enabled)
        {
            if (_damageable)
            {
                _hitboxDamageableColor.a = 0.35f;
                Gizmos.color = _hitboxDamageableColor;
            }
            else
            {
                _hitboxNonDamageableColor.a = 0.4f;
                Gizmos.color = _hitboxNonDamageableColor;
            }
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

            Vector2 gizmoPosition = new Vector2(_boxCollider.size.x, _boxCollider.size.y);
            Gizmos.DrawCube(Vector3.zero, gizmoPosition);
            Gizmos.DrawWireCube(Vector3.zero, gizmoPosition);
            Gizmos.DrawWireCube(Vector3.zero, gizmoPosition);
        }
    }
}
#endif