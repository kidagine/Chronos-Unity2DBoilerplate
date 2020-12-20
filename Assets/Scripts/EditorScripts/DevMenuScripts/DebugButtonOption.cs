#if UNITY_EDITOR
using TMPro;
using UnityEngine;

public class DebugButtonOption : MonoBehaviour
{
	[SerializeField] private DebugConsole _debugConsole = default;
	[SerializeField] private GameObject _currentMenu = default;
	[SerializeField] private GameObject _newMenu = default;
	[SerializeField] private GameObject _activeOption = default;
	[SerializeField] private TextMeshProUGUI _optionText = default;
	[SerializeField] private GameObject _selectedImage = default;


	public void ClickDebugOption()
	{
		_debugConsole.OpenMenu(_newMenu, _currentMenu, _activeOption, transform.GetChild(0).gameObject);
	}

	public void SelectDebugOption()
	{
		_optionText.color = Color.yellow;
		_selectedImage.SetActive(true);
	}

	public void DeselectDebugOption()
	{
		_optionText.color = Color.white;
		_selectedImage.SetActive(false);
	}
}
#endif