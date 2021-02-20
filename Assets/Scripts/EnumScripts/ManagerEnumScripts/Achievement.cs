using System;
using UnityEngine;

[Serializable]
public enum AchievementEnum { ACH_WIN_ONE_GAME };

public class Achievement : MonoBehaviour
{
	[SerializeField] private AchievementEnum _achievementEnum = default;

	public AchievementEnum AchievementsEnums { get { return _achievementEnum; } private set { } }
}
