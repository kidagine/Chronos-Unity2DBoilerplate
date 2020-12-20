#if UNITY_EDITOR
using UnityEngine;

public struct Print
{
	public object Message;
	public bool PrintToScreen;
	public bool PrintToLog;
	public Color TextColor;
	public float Duration;


	public Print(object message, bool printToScreen, bool printToLog, Color textColor, float duration)
	{
		Message = message;
		PrintToScreen = printToScreen;
		PrintToLog = printToLog;
		TextColor = textColor;
		Duration = duration;
	}
}
#endif