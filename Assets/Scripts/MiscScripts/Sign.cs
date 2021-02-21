using UnityEngine;

[RequireComponent(typeof(Tag))]
[RequireComponent(typeof(DialogueStarter))]
public class Sign : MonoBehaviour, ITriggerResponder
{
	[SerializeField] private GameObject _promptCanvas = default;
	private Tag _tag;
	private DialogueStarter _dialogueStarter;


	void Awake()
	{
		_tag = GetComponent<Tag>();
		_dialogueStarter = GetComponent<DialogueStarter>();
	}

	public string ReceiveActivatorTag()
	{
		return _tag.TagEnum.ToString();
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
		_dialogueStarter.StartDialogue();
	}
}
