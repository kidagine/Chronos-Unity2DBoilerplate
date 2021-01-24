using UnityEngine;

public class Sign : MonoBehaviour, ITriggerResponder
{
	[SerializeField] private Tags _tags = default;


	public string ReceiveActivatorTag()
	{
		return _tags.TagEnum.ToString();
	}

	public void Trigger()
	{
		Debug.Log("trigger");
	}
}
