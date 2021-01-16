using UnityEngine;

public class BaseButtonAnimationEvents : MonoBehaviour
{
    [SerializeField] private BaseButton _baseButton = default;


    public void OnClickedEndAnimationEvent()
    {
        _baseButton.OnClickedAnimationEnd();
    }
}
