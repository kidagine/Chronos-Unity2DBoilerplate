using UnityEngine;

public class Trigger : MonoBehaviour
{
	private ITriggerResponder _triggerResponder;
	private string _activatorTag;


	void Awake()
	{
		_triggerResponder = GetComponent<ITriggerResponder>();
		_activatorTag = _triggerResponder.ReceiveActivatorTag();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.root.CompareTag(_activatorTag))
		{
			_triggerResponder.Trigger();
		}
	}
}
