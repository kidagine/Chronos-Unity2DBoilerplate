﻿using System;
using UnityEngine;

[Serializable]
public enum LevelEnum { SplashScreen, PressStart, MainMenu, FirstLevel, SecondLevel, Credits, DebugAdditive };


public class Levels : MonoBehaviour
{
	[SerializeField] private LevelEnum _levelsEnum = default;

	public LevelEnum LevelsEnums { get { return _levelsEnum; } private set { } }
}
