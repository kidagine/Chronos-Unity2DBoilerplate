using System;
using TMPro;
using UnityEngine;

public class GameStatistics : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _fpsText = default;
	[SerializeField] private GameObject _fpsDisplay = default;
	private readonly float _maxFpsCooldown = 0.5f;
	private float _currrentFpsCooldown;
	private bool _isShowingFPS;


	void Update()
	{
		if (_isShowingFPS)
		{
			_currrentFpsCooldown -= Time.deltaTime;
			if (_currrentFpsCooldown <= 0)
			{
				_currrentFpsCooldown = _maxFpsCooldown;
				double fps = 1.0 / Time.deltaTime;
				_fpsText.text = Math.Round(fps).ToString() + " FPS";
			}
		}
	}

	public void ShowFPS(bool state)
	{
		_isShowingFPS = state;
		_fpsDisplay.SetActive(state);
	}
}
