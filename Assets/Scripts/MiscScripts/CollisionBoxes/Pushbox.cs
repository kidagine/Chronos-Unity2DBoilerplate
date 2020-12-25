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


    void Awake()
    {
        if (_isGroundCheck)
        {
            _pushboxResponder = _pushboxResponderObject.GetComponent<IPushboxResponder>();
        }
    }

	void Update()
	{
        if (_isGroundCheck)
        {
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0.0f, Vector2.zero, 0.0f, LayerProvider.GetLayerMask(LayerMasksEnum.Ground));
            if (hit.collider != null)
            {
                if (hit.normal == Vector2.up)
                {
                    _pushboxResponder.OnGrounded();
                }
            }
            else
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