using UnityEngine;

public class Edgebox : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider = default;
    private readonly string _fallboxLayerMaskName = "Fallbox";
    private Color _fallboxColor = Color.cyan;
    private LayerMask _fallBoxLayerMask;


    void Start()
    {
        _fallBoxLayerMask = LayerMask.GetMask(_fallboxLayerMaskName);
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, _boxCollider.bounds.size, 0.0f, Vector2.zero, 0.0f, _fallBoxLayerMask);
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out Fallbox fallbox))
            {
                fallbox.SetSafeLocation(hit.point);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (_boxCollider.enabled)
        {
            _fallboxColor.a = 0.6f;
            Gizmos.color = _fallboxColor;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

            Vector2 gizmoPosition = new Vector2(_boxCollider.bounds.size.x, _boxCollider.bounds.size.y);
            Gizmos.DrawCube(Vector3.zero, gizmoPosition);
            Gizmos.DrawWireCube(Vector3.zero, gizmoPosition);
            Gizmos.DrawWireCube(Vector3.zero, gizmoPosition);
        }
    }
}

