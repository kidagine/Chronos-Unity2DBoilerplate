﻿using UnityEngine;

public class Sign : MonoBehaviour, ITriggerResponder
{
	[SerializeField] private Tags _tags = default;
	[SerializeField] private GameObject _promptCanvas = default;
	[SerializeField] private DialogueStarter dialogueStarter = default;

	
	public string ReceiveActivatorTag()
	{
		return _tags.TagEnum.ToString();
	}

	public void TriggerEnter()
	{
		_promptCanvas.SetActive(true);
	}

	public void TriggerExit()
	{
		_promptCanvas.SetActive(false);
	}

	public void Trigger()
	{
		_promptCanvas.SetActive(false);
		dialogueStarter.StartDialogue();
	}
}