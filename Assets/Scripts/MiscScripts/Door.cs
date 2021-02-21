using UnityEngine;

[RequireComponent(typeof(Level))]
[RequireComponent(typeof(Tag))]
public class Door : MonoBehaviour, ITriggerResponder
{
	[SerializeField] private GameObject _promptCanvas = default;
	private Level _level;
	private Tag _tag;


	void Awake()
	{
		_level = GetComponent<Level>();
		_tag = GetComponent<Tag>();
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
		LevelManager.Instance.GoToLevel(_level);
	}
}
