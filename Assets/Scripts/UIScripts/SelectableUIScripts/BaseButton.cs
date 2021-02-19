using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Audio))]
public class BaseButton : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler
{
    [SerializeField] private EventSystem _eventSystem = default;
    [SerializeField] private UnityEvent _onClickedAnimationEnd = default;
    protected Animator _animator = default;
    protected Audio _audio = default;


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponent<Audio>();
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
        if (_eventSystem.currentSelectedGameObject != gameObject)
        {
            _eventSystem.SetSelectedGameObject(gameObject);
        }
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
