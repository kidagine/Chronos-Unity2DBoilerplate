﻿using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Audio))]
public class ClickablePrompt : Prompt, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	[SerializeField] private TextMeshProUGUI _text = default;
	private Audio _audio;


	void Awake()
	{
		_audio = GetComponent<Audio>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		_audio.Sound("Pressed").Play();
		_text.color = Color.grey;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_audio.Sound("Selected").Play();
		_text.color = Color.white;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_text.color = Color.grey;
	}
}
