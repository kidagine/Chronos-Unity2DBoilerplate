public class DeleteSaveMenu : BaseMenu
{
	public void Delete()
	{
		SaveManager.Instance.Delete(SaveManager.Instance.SelectedSaveSlot);
	}
}
