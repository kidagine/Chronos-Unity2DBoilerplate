#if UNITY_EDITOR
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Triggererbox : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider = default;
    private Color _triggererboxColor = Color.black;


    private void OnDrawGizmos()
    {
        if (_boxCollider.enabled)
        {
            _triggererboxColor.a = 1.0f;
            Gizmos.color = _triggererboxColor;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

            Vector2 gizmoPosition = new Vector2(_boxCollider.size.x, _boxCollider.size.y);
            Gizmos.DrawWireCube(Vector3.zero, gizmoPosition);
            Gizmos.DrawWireCube(Vector3.zero, gizmoPosition);
        }
    }
}
#endif