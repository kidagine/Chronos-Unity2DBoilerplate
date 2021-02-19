using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Audio))]
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Animator))]
public class BaseButton : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler
{
    [SerializeField] private UnityEvent _onClickedAnimationEnd = default;
    protected Audio _audio;
    protected Button _button;
    protected Animator _animator;


    void Awake()
    {
        _audio = GetComponent<Audio>();
        _button = GetComponent<Button>();
        _animator = GetComponent<Animator>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        _audio.Sound("Selected").Play();
        _animator.SetBool("IsSelected", true);
    }

	public void OnDeselect(BaseEventData eventData)
    {
        _animator.SetBool("IsSelected", false);
    }

	public void OnPointerEnter(PointerEventData eventData)
	{
        _button.Select();
    }

	public virtual void OnPress()
	{
        _audio.Sound("Pressed").Play();
        _animator.SetTrigger("Clicked");
    }

    public void OnClickedEndAnimationEvent()
    {
        _animator.Rebind();
        _onClickedAnimationEnd?.Invoke();
    }
}
