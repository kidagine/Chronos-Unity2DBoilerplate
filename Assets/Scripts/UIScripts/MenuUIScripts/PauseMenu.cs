public class PauseMenu : BaseMenu
{
	public void TogglePauseMenu()
	{
		gameObject.SetActive(!gameObject.activeSelf);
	}
}