using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugGameMenu : MonoBehaviour, ISubMenu
{
	[SerializeField] private Selectable _startingOption = default;
	[SerializeField] private TextMeshProUGUI _timeScaleText = default;


	public void SetTimeScale(float timeScale)
	{
		_timeScaleText.text = timeScale.ToString("F1");
		Time.timeScale = timeScale;
	}

	public void Activate()
	{
		_startingOption.Select();
	}
}
