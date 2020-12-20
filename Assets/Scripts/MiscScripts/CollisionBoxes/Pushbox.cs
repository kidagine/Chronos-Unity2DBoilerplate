#if UNITY_EDITOR
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Pushbox : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider = default;
    [SerializeField] private bool _showGizmo = true;
    [SerializeField] private bool _isGroundCheck = default;
    [ConditionalHide("_isGroundCheck", true)]
    [SerializeField] private GameObject _pushboxResponderObject = default;
    private Color _pushboxColor = Color.blue;
    private IPushboxResponder _pushboxResponder;
    private int _collisionsCount;


    void Awake()
    {
        if (_isGroundCheck)
            _pushboxResponder = _pushboxResponderObject.GetComponent<IPushboxResponder>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_isGroundCheck)
        {
            Vector2 contactPoint = other.contacts[0].normal;
            if (contactPoint == Vector2.up)
            {
                _collisionsCount++;
                _pushboxResponder.OnGrounded();
            }
        }
    }

	private void OnCollisionExit2D(Collision2D collision)
	{
        if (_isGroundCheck)
        {
            _collisionsCount--;
            if (_collisionsCount == 0)
            {
                _pushboxResponder.OnAir();
            }
        }
    }

	private void OnDrawGizmos()
    {
        if (_boxCollider.enabled && _showGizmo)
        {
            _pushboxColor.a = 0.6f;
            Gizmos.color = _pushboxColor;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

            Vector2 gizmoPosition = new Vector2(_boxCollider.size.x, _boxCollider.size.y);
            Gizmos.DrawCube(Vector3.zero, gizmoPosition);
            Gizmos.DrawWireCube(Vector3.zero, gizmoPosition);
            Gizmos.DrawWireCube(Vector3.zero, gizmoPosition);
        }
    }
}
#endif