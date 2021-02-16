using System;
using UnityEngine;

[Serializable]
public enum LevelEnum { SplashScreen, PressStart, MainMenu, FirstLevel, SecondLevel, Credits, DebugAdditive };


public class Level : MonoBehaviour
{
	[SerializeField] private LevelEnum _levelsEnum = default;

	public LevelEnum LevelsEnum { get { return _levelsEnum; } private set { } }
}
