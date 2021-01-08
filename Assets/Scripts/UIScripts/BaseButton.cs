using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class BaseButton : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator _animator = default;
    [SerializeField] private EntityAudio _entityAudio = default;
    [SerializeField] private EventSystem _eventSystem = default;


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

	public void OnPress()
	{
        _entityAudio.Play("Pressed");
        _animator.SetTrigger("Clicked");
    }
}
