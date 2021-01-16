using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Camera2D : MonoBehaviour
{
    [SerializeField] private Transform[] _targets = default;
    [SerializeField] private Vector2 _offset = default;
    [SerializeField] private bool _lockVerticalTracking = default;
    [SerializeField] private bool _lockHorizontalTracking = default;
    private Vector3 _target;
    private float _zOffset;


    void Awake()
    {
        _zOffset = transform.position.z;
    }

	void Update()
	{
        Vector3 t = Vector3.zero;
		for (int i = 0; i < _targets.Length; i++)
		{
            t += _targets[i].position;
		}
        _target = t / _targets.Length;
	}

	void LateUpdate()
    {
        {
            Vector3 trackingPosition = new Vector3(_target.x + _offset.x, _target.y + _offset.y, _zOffset);
            if (_lockVerticalTracking)
            {
                trackingPosition.y = transform.position.y;
            }
            if (_lockHorizontalTracking)
            {
                trackingPosition.x = transform.position.x;
            }
            transform.position = trackingPosition;
        }
    }
}
