using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class BaseButton : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected Animator _animator = default;
    [SerializeField] protected EntityAudio _entityAudio = default;
    [SerializeField] private EventSystem _eventSystem = default;
    [SerializeField] private UnityEvent _onClickedAnimationEnd = default;


    public void OnSelect(BaseEventData eventData)
    {
        _entityAudio.Play("Selected");
        _animator.SetBool("IsSelected", true);
    }

	public void OnDeselect(BaseEventData eventData)
    {
        _animator.SetBool("IsSelected", false);
    }

	public void OnPointerEnter(PointerEventData eventData)
	{
        _eventSystem.SetSelectedGameObject(gameObject);
    }

	public void OnPointerExit(PointerEventData eventData)
	{
        if (_eventSystem.currentSelectedGameObject != gameObject)
        {
            _eventSystem.SetSelectedGameObject(null);
        }
    }

	public virtual void OnPress()
	{
        _entityAudio.Play("Pressed");
        _animator.SetTrigger("Clicked");
    }

    public void OnClickedEndAnimationEvent()
    {
        _animator.Rebind();
        _onClickedAnimationEnd?.Invoke();
    }
}
