using UnityEngine;

public class Door : MonoBehaviour, ITriggerResponder
{
	[SerializeField] private Level _levels = default;
	[SerializeField] private Tags _tags = default;
	[SerializeField] private GameObject _promptCanvas = default;


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
		LevelManager.Instance.GoToLevel(_levels);
	}
}
