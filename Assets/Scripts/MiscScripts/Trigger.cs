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
			_triggerResponder.TriggerEnter();
			if (collision.transform.root.TryGetComponent(out IExecutorResponder executorResponder))
			{
				executorResponder.TriggerEnter(_triggerResponder);
			}
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.transform.root.CompareTag(_activatorTag))
		{
			_triggerResponder.TriggerExit();
			if (collision.transform.root.TryGetComponent(out IExecutorResponder executorResponder))
			{
				executorResponder.TriggerExit();
			}
		}
	}
}
