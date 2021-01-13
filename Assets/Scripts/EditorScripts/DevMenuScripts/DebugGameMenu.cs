using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugGameMenu : MonoBehaviour
{
	[SerializeField] private Selectable _startingOption = default;
	[SerializeField] private TextMeshProUGUI _timeScaleText = default;


	private void OnEnable()
	{
		_startingOption.Select();
	}

	public void SetTimeScale(float timeScale)
	{
		_timeScaleText.text = timeScale.ToString("F1");
		Time.timeScale = timeScale;
	}
}
