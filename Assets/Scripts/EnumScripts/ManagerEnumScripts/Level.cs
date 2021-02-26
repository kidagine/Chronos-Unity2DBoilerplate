using System;
using UnityEngine;

[Serializable]
public enum LevelEnum { SplashScreen, PressStart, MainMenu, FirstLevel, SecondLevel, Credits, InitializerAdditive, DebugAdditive };


public class Level : MonoBehaviour
{
	[SerializeField] private LevelEnum _levelEnum = default;

	public LevelEnum LevelEnum { get { return _levelEnum; } private set { } }
}
