public interface ITriggerResponder
{
	string ReceiveActivatorTag();
	void TriggerEnter();
	void TriggerExit();
	void Trigger();
}
