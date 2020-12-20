using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(BoxCollider2D))]
public class Fallbox : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider = default;
    [SerializeField] private GameObject _mainObject = default;
    private Color _fallBoxColor = Color.yellow;
    private IFallboxResponder _fallboxResponder;


    void Start()
    {
        _fallboxResponder = _mainObject.GetComponent<IFallboxResponder>();
    }


    public void SetSafeLocation(Vector2 position)
    {
        _fallboxResponder.SetSafeLocation(position);
    }

    public bool Fall()
    {
        return _fallboxResponder.StartFall();
    }

    private void OnDrawGizmos()
    {
        if (_boxCollider.enabled)
        {
            _fallBoxColor.a = 0.6f;
            Gizmos.color = _fallBoxColor;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

            Vector2 gizmoPosition = new Vector2(_boxCollider.size.x, _boxCollider.size.y);
            Gizmos.DrawCube(Vector3.zero, gizmoPosition);
            Gizmos.DrawWireCube(Vector3.zero, gizmoPosition);
            Gizmos.DrawWireCube(Vector3.zero, gizmoPosition);
        }
    }
}
