using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private Vector2 _hitboxSize = default;
    private Color _hitboxColor = Color.red;
    private IHitboxResponder _hitboxResponder;
        

	void OnEnable()
	{
        _hitboxResponder = GetComponent<IHitboxResponder>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, _hitboxSize, 0.0f, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out Hurtbox hurtbox))
            {
                if (_hitboxResponder != null)
                    _hitboxResponder.HitboxCollided(hit, hurtbox);
            }
            else
            {
                _hitboxColor = Color.red;
            }
        }
	}

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        _hitboxColor.a = 0.6f;
        Gizmos.color = _hitboxColor;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

        Gizmos.DrawCube(Vector3.zero, new Vector3(_hitboxSize.x, _hitboxSize.y, 1.0f));
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(_hitboxSize.x, _hitboxSize.y, 1.0f));
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(_hitboxSize.x * 1.01f, _hitboxSize.y * 1.01f, 1.0f));
    }
#endif
}