﻿#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;

public static class Printer
{
	private static readonly List<Print> _prints = new List<Print>();
	private static PrinterMO _printerMO;
	private static bool _isLoaded;


	public static void Log(object message, bool printToScreen = true, bool printToLog = true, Color textColor = default, float duration = 2.0f, bool flipToRight = false)
	{
		Print print = new Print(message, printToScreen, printToLog, textColor, duration, flipToRight);
		if (_isLoaded)
		{
			_printerMO.Log(print);
		}
		else
		{
			_prints.Add(print);
		}
	}

	public static void LogWarning(object message, bool printToScreen = true, bool printToLog = true, float duration = 2.0f, bool flipToRight = false)
	{
		Print print = new Print(message, printToScreen, printToLog, Color.yellow, duration, flipToRight);
		if (_isLoaded)
		{
			_printerMO.LogWarning(print);
		}
		else
		{
			_prints.Add(print);
		}
	}

	public static void LogError(object message, bool printToScreen = true, bool printToLog = true, float duration = 2.0f, bool flipToRight = false)
	{
		Print print = new Print(message, printToScreen, printToLog, Color.red, duration, flipToRight);
		if (_isLoaded)
		{
			_printerMO.LogError(print);
		}
		else
		{
			_prints.Add(print);
		}
	}

	public static void SetLoaded()
	{
		_isLoaded = true;
		GameObject _printerGameObject = GameObject.Find("Debug_printer");
		_printerMO = _printerGameObject.GetComponent<PrinterMO>();

		foreach (Print print in _prints)
		{
			_printerMO.Log(print);
		}
	}
}
#endif