using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    [SerializeField] private bool _permanentlyHide = default;
    [SerializeField] private bool _hideOnStart = true;


    void Start()
    {
        if (_hideOnStart)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
        if (!_permanentlyHide)
        {
            InputManager.Instance.ControlsChanged += SetCursorVisibility;
            GameManager.Instance.OnGamePauseStateChange += SetCursorVisibility;
        }
    }

    public void SetCursorVisibility()
    {
        if (!_permanentlyHide)
        {
            if (GameManager.Instance.GamePauseState)
            {
                if (InputManager.Instance.ActiveControlScheme == ControlSchemeEnum.KeyboardMouse)
                {
                    Cursor.visible = true;
                }
                else
                {
                    Cursor.visible = false;
                }
            }
            else
            {
                Cursor.visible = false;
            }
        }
        else
        {
            Cursor.visible = false;
        }
    }

    void OnDisable()
    {
        if (!_permanentlyHide)
        {
            InputManager.Instance.ControlsChanged -= SetCursorVisibility;
            GameManager.Instance.OnGamePauseStateChange -= SetCursorVisibility;
        }
    }
}
