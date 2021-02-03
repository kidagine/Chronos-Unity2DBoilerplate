#if UNITY_EDITOR

public class DebugStateMenu : BaseMenu
{
	public void Save()
	{
		SaveManager.Instance.Save();
	}

	public void Load()
	{
		SaveManager.Instance.Load();
	}
}
#endif