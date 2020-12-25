using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider = default;
    [SerializeField] private TextMeshProUGUI _maxHealthText = default;
    [SerializeField] private TextMeshProUGUI _healthText = default;


    public void SetMaxHealth(int maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = maxHealth;
        _maxHealthText.text = maxHealth.ToString() + "/";
        _healthText.text = maxHealth.ToString();
    }

    public void SetHealth(int health)
    {
        _healthSlider.value = health;
        _healthText.text = health.ToString();
    }
}
