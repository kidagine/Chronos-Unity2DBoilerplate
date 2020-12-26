using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Pitbox : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider = default;
    private readonly string _fallboxLayerMaskName = "Fallbox";
    private Color _fallboxColor = Color.magenta;
    private LayerMask _fallBoxLayerMask;
    private bool _hasStartedFalling;


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
                if (IsFallBoxInside(_boxCollider, (BoxCollider2D)hit.collider) && !_hasStartedFalling)
                {
                    _hasStartedFalling = fallbox.Fall();
                }
            }
        }
        else
        {
            _hasStartedFalling = false;
        }
    }

    bool IsFallBoxInside(BoxCollider2D enterableCollider, BoxCollider2D enteringCollider)
    {
        Bounds enterableBounds = enterableCollider.bounds;
        Bounds enteringBounds = enteringCollider.bounds;
        Vector2 center = enteringBounds.center;
        Vector2 extents = enteringBounds.extents;
        Vector2[] enteringVerticles = new Vector2[4];

        enteringVerticles[0] = new Vector2(center.x + extents.x, center.y + extents.y);
        enteringVerticles[1] = new Vector2(center.x - extents.x, center.y + extents.y);
        enteringVerticles[2] = new Vector2(center.x + extents.x, center.y - extents.y);
        enteringVerticles[3] = new Vector2(center.x - extents.x, center.y - extents.y);
        foreach (Vector2 verticle in enteringVerticles)
        {
            if (!enterableBounds.Contains(verticle))
            {
                return false;
            }
        }
        return true;
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
