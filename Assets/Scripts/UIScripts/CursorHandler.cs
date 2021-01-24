using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    [SerializeField] private bool _permanentlyHide = default;
    
    
    void Start()
    {
        if (_permanentlyHide)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
            InputManager.Instance.ControlsChanged += SetCursorVisibility;
        }
    }

    private void SetCursorVisibility(bool isControllerActive)
    {
        if (isControllerActive)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }

	void OnDisable()
    {
        if (!_permanentlyHide)
        {
            InputManager.Instance.ControlsChanged -= SetCursorVisibility;
        }
    }
}
