#if UNITY_EDITOR
using TMPro;
using UnityEngine;

public class DebugPlayerMenu : BaseMenu
{
	[SerializeField] private TextMeshProUGUI _invicibilityText = default;
	[SerializeField] private TextMeshProUGUI _healthText = default;
	[SerializeField] private TextMeshProUGUI _speedText = default;
	[SerializeField] private TextMeshProUGUI _jumpCountText = default;
	private PlayerStats _playerStats;


	void Awake()
	{
		_playerStats = GameManager.Instance.GetPlayer().GetComponent<PlayerStats>();
	}

	public void SetInvicibility(bool state)
	{
		if (state)
		{
			_invicibilityText.text = "On";
		}
		else
		{
			_invicibilityText.text = "Off";
		}
	}

	public void SetHealth(float value)
	{
		_healthText.text = value.ToString("F1");
		_playerStats.currentHealth = (int)value;
	}

	public void SetSpeed(float value)
	{
		_speedText.text = value.ToString("F1");
		_playerStats.currentSpeed = value;
	}

	public void SetJumpCount(float value)
	{
		_jumpCountText.text = value.ToString("F1");
		_playerStats.jumpCount = (int)value;
	}
}
#endif