using TMPro;
using UnityEngine;

public class DebugGameMenu : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _timeScaleText = default;
	public void SetTimeScale(float timeScale)
	{
		_timeScaleText.text = timeScale.ToString("F1");
		Time.timeScale = timeScale;
	}
}
