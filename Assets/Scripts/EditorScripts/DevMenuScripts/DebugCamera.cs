#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.UI;

public class DebugCamera : MonoBehaviour
{
	[SerializeField] private DebugCameraMenu _debugCameraMenu = default;
	[SerializeField] private Toggle _debugToggleCamera = default;
	private Vector2 _movementInput;
	private float _cameraSpeed = 1.5f;


	void Update()
	{
		transform.Translate(_movementInput * _cameraSpeed);
	}

	public void CloseCamera()
	{
		_debugCameraMenu.ToggleDebugCamera(false);
	}

	public void SetCameraMovement(Vector2 movementInput)
	{
		_movementInput = movementInput;
	}

	public void SetCameraZoom(Vector2 zoomInput)
	{
		Vector3 zoom = new Vector3(transform.position.x, transform.position.y, transform.position.z + zoomInput.y);
		transform.position = zoom;
	}

	public void SetCameraSpeedEnabled(bool enable)
	{
		if (enable)
		{
			_cameraSpeed = 3.0f;
		}
		else
		{
			_cameraSpeed = 1.5f;
		}
	}
}
#endif