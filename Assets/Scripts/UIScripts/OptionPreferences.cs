using UnityEngine;

public class OptionPreferences : MonoBehaviour
{
	[Header("Gameplay")]
	[SerializeField] private BaseSlider _mussicSlider = default;
	[Header("Controls")]
	[SerializeField] private BaseSlider _mussSicSlider = default;
	[Header("Video")]
	[SerializeField] private BaseSlider _muSssicSlider = default;
	[Header("Audio")]
	[SerializeField] private BaseSlider _musicSlider = default;
	[SerializeField] private BaseSlider _vfxSlider = default;
	[SerializeField] private BaseSlider _uiSlider = default;
	private readonly string _musicKey = "Music";
	private readonly string _vfxKey = "VFX";
	private readonly string _uiKey = "UI";


	void Start()
	{
		//_musicSlider.SetValue(PlayerPrefs.GetFloat(_musicKey, 1.0f));
		//_vfxSlider.SetValue(PlayerPrefs.GetFloat(_vfxKey, 1.0f));
		//_uiSlider.SetValue(PlayerPrefs.GetFloat(_uiKey, 1.0f));
	}

	public void SetMusicPreference(float value)
	{
		PlayerPrefs.SetFloat(_musicKey, value);
	}

	public void SetVFXPreference(float value)
	{
		PlayerPrefs.SetFloat(_vfxKey, value);
	}

	public void SetUIPreference(float value)
	{
		PlayerPrefs.SetFloat(_uiKey, value);
	}
}
