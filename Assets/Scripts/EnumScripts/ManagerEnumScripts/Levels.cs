using System;
using UnityEngine;

[Serializable]
public enum LevelsEnums { SplashScreen, PressStart, MainMenu, Game, Credits };

public class Levels : MonoBehaviour
{
	[SerializeField] private LevelsEnums _levelsEnum = default;

	public LevelsEnums LevelsEnums { get { return _levelsEnum; } private set { } }
}
