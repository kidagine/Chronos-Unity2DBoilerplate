using UnityEngine;

public class Sign : MonoBehaviour, ITriggerResponder
{
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
		Debug.Log("trigger");
	}
}
