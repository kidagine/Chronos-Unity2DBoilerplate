using UnityEngine;

public class PlayerInteract : MonoBehaviour, IExecutorResponder
{
	private ITriggerResponder _triggerResponder;


	public void InteractAction()
	{
		if (_triggerResponder != null)
		{
			_triggerResponder.Trigger();
		}
	}

	public void TriggerEnter(ITriggerResponder triggerResponder)
	{
		_triggerResponder = triggerResponder;
	}

	public void TriggerExit()
	{
		_triggerResponder = null;
	}
}
