using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickablePrompt : Prompt, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	[SerializeField] private TextMeshProUGUI _text = default;
	[SerializeField] private EntityAudio _entityAudio = default;


	public void OnPointerClick(PointerEventData eventData)
	{
		_entityAudio.Sound("Pressed").Play();
		_text.color = Color.grey;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_entityAudio.Sound("Selected").Play();
		_text.color = Color.white;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_text.color = Color.grey;
	}
}
