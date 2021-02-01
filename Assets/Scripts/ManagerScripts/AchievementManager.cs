using Steamworks;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
	void Start()
	{
		//_player.OnExampleEvent += SetAchievement(AchievementEnum.ACH_WIN_ONE_GAME);	
	}

	private void SetAchievement(AchievementEnum achievementEnum)
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.SetAchievement(achievementEnum.ToString());
			SteamUserStats.StoreStats();
		}
	}
}
