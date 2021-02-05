#if UNITY_EDITOR
using TMPro;
using UnityEngine;

public class DebugPlayerMenu : BaseMenu
{
	[SerializeField] private TextMeshProUGUI _healthText = default;
	[SerializeField] private TextMeshProUGUI _speedText = default;
	[SerializeField] private TextMeshProUGUI _jumpCountText = default;
	[SerializeField] private TextMeshProUGUI _currentHealthText = default;
	[SerializeField] private TextMeshProUGUI _currentSpeedText = default;
	[SerializeField] private TextMeshProUGUI _currentJumpCountText = default;
	private PlayerStats _playerStats;


	void Start()
	{
		_playerStats = GameManager.Instance.GetPlayer().GetComponent<PlayerStats>();
		_healthText.text = _playerStats.health.ToString("F1");
		_speedText.text = _playerStats.speed.ToString("F1");
		_jumpCountText.text = _playerStats.jumpCount.ToString("F1");
		_currentHealthText.text = _playerStats.currentHealth.ToString("F1");
		_currentSpeedText.text = _playerStats.currentSpeed.ToString("F1");
		_currentJumpCountText.text = _playerStats.currentJumpCount.ToString("F1");
	}

	public void SetHealth(float value)
	{
		_healthText.text = value.ToString("F1");
		_playerStats.health = (int)value;
	}

	public void SetSpeed(float value)
	{
		_speedText.text = value.ToString("F1");
		_playerStats.speed = value;
	}

	public void SetJumpCount(float value)
	{
		_jumpCountText.text = value.ToString("F1");
		_playerStats.jumpCount = (int)value;
	}

	public void SetCurrentHealth(float value)
	{
		_currentHealthText.text = value.ToString("F1");
		_playerStats.currentHealth = (int)value;
	}

	public void SetCurrentSpeed(float value)
	{
		_currentSpeedText.text = value.ToString("F1");
		_playerStats.currentSpeed = value;
	}

	public void SetCurrentJumpCount(float value)
	{
		_currentJumpCountText.text = value.ToString("F1");
		_playerStats.currentJumpCount = (int)value;
	}
}
#endif