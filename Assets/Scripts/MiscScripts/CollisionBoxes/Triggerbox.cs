using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Triggerbox : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider = default;
    [SerializeField] private GameObject _mainObject = default;
    [SerializeField] private bool _triggerOnExit = default;
    private Color _triggerboxColor = Color.white;
    private ITriggerboxResponder _triggerResponder;
    private LayerMask _triggererboxLayerMask;
    private readonly string _triggererBoxLayerMaskName = "Triggererbox";
    private bool _hasEntered;


    void Awake()
    {
        _triggererboxLayerMask = LayerMask.GetMask(_triggererBoxLayerMaskName);
        _triggerResponder = _mainObject.GetComponent<ITriggerboxResponder>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, _boxCollider.bounds.size, 0.0f, Vector2.zero, 0.0f, _triggererboxLayerMask);
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out Triggererbox triggererbox) && !_hasEntered)
            {
                _triggerResponder.TriggerEnter();
                _hasEntered = true;
            }
        }
        else
        {
            if (_triggerOnExit && _hasEntered)
            {
                _triggerResponder.TriggerExit();
            }
            _hasEntered = false;
        }
    }

#if UNITY_EDITOR
	private void OnDrawGizmos()
    {
        if (_boxCollider.enabled)
        {
            _triggerboxColor.a = 1.0f;
            Gizmos.color = _triggerboxColor;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

            Vector2 gizmoPosition = new Vector2(_boxCollider.bounds.size.x, _boxCollider.bounds.size.y);
            Gizmos.DrawWireCube(Vector3.zero, gizmoPosition);
            Gizmos.DrawWireCube(Vector3.zero, gizmoPosition);
        }
    }
}
#endif