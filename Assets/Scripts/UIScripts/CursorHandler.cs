using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    [SerializeField] private bool _isCursorVisible = default;
    [SerializeField] private bool _hideOnStart = true;
    [SerializeField] private bool _uiOnly = default;


	void Start()
    {
        if (_hideOnStart)
        {
            Cursor.visible = false;
        }
        InputManager.Instance.ControlsChanged += UpdateCursorVisibility;
        GameManager.Instance.OnGamePauseStateChange += UpdateCursorVisibility;
    }

    public void UpdateCursorVisibility()
    {
        if (_isCursorVisible)
        {
            if (GameManager.Instance.GamePauseState || _uiOnly)
            {
                if (InputManager.Instance.ActiveControlScheme == ControlSchemeEnum.KeyboardMouse)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void SetCursorVisibility(bool isCursorVisible)
    {
        _isCursorVisible = isCursorVisible;
        UpdateCursorVisibility();
    }

    void OnDestroy()
    {
        InputManager.Instance.ControlsChanged -= UpdateCursorVisibility;
        GameManager.Instance.OnGamePauseStateChange -= UpdateCursorVisibility;
    }
}
