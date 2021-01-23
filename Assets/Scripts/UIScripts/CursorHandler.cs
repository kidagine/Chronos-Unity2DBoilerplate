using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    void Start()
    {
        InputManager.Instance.ControlsChanged += SetCursorVisibility;
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
}
