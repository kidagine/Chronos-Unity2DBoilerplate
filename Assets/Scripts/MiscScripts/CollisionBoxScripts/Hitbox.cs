﻿using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private Vector2 _hitboxSize = default;
    [SerializeField] private Vector2 _offset = default;
    private Color _hitboxColor = Color.red;
    private LayerMask _groundLayerMask;
    private LayerMask _hurtboxLayerMask;
    private IHitboxResponder _hitboxResponder;
    private bool _hasHit;


    void Start()
	{
        _hitboxResponder = GetComponent<IHitboxResponder>();
        _hurtboxLayerMask = LayerProvider.GetLayerMask(LayerMaskEnum.Hurtbox);
        _groundLayerMask = LayerProvider.GetLayerMask(LayerMaskEnum.Ground);
    }

    void Update()
    {
        Vector2 hitboxPosition = new Vector2(transform.position.x + (_offset.x * transform.root.localScale.x), transform.position.y + (_offset.y * transform.root.localScale.y));
        RaycastHit2D[] hit = Physics2D.BoxCastAll(hitboxPosition, _hitboxSize, 0.0f, Vector2.zero, 0.0f, _hurtboxLayerMask | _groundLayerMask);
        if (hit.Length > 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].collider != null)
                {
                    if (_hitboxResponder != null && !hit[i].collider.transform.IsChildOf(transform.root) && !_hasHit)
                    {
                        if (hit[i].collider.transform.TryGetComponent(out Hurtbox hurtbox))
                        {
                            _hitboxResponder.HitboxCollided(hit[i], hurtbox);
                        }
                        else
                        {
                            _hitboxResponder.HitboxCollided(hit[i]);
                        }
                    }
                }
            }
            if (!_hasHit)
            {
                _hasHit = true;
            }
        }
    }

    void OnEnable()
	{
        _hasHit = false;
	}

	void OnDisable()
	{
        _hasHit = false;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        _hitboxColor.a = 0.6f;
        Vector2 hitboxPosition = new Vector2(transform.position.x + (_offset.x * transform.root.localScale.x), transform.position.y + (_offset.y * transform.root.localScale.y));
        Gizmos.color = _hitboxColor;
        Gizmos.matrix = Matrix4x4.TRS(hitboxPosition, transform.rotation, Vector2.one);

        Gizmos.DrawCube(Vector3.zero, new Vector3(_hitboxSize.x, _hitboxSize.y, 1.0f));
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(_hitboxSize.x, _hitboxSize.y, 1.0f));
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(_hitboxSize.x * 1.01f, _hitboxSize.y * 1.01f, 1.0f));
    }
#endif
}