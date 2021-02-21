#if UNITY_EDITOR
using TMPro;
using UnityEngine;

public class DebugGameMenu : BaseMenu
{
	[SerializeField] private TextMeshProUGUI _timeScaleText = default;


	public void SetTimeScale(float timeScale)
	{
		_timeScaleText.text = timeScale.ToString("F1");
		Time.timeScale = timeScale;
	}

	public void NextCheckpoint()
	{
		CheckpointManager.Instance.GoToNextCheckpoint();
	}

	public void PreviousCheckpoint()
	{
		CheckpointManager.Instance.GoToPreviousCheckpoint();
	}
	public void Test()
	{
		Debug.Log("tesT");
	}
}
#endif