using UnityEngine;

public class AudioMenu : BaseMenu
{
	[SerializeField] private BaseSlider _musicSlider = default;
	[SerializeField] private BaseSlider _vfxSlider = default;
	[SerializeField] private BaseSlider _uiSlider = default;
	private EntityAudio _audio;


	void Awake()
	{
		_audio = GetComponent<EntityAudio>();
	}

	public void InitializePreferences()
	{
		_musicSlider.SetValue(PlayerPrefs.GetFloat("musicVolume", _musicSlider.DefaultValue));
		_vfxSlider.SetValue(PlayerPrefs.GetFloat("vfxVolume", _musicSlider.DefaultValue));
		_uiSlider.SetValue(PlayerPrefs.GetFloat("uiVolume", _musicSlider.DefaultValue));
	}

	public void ConfirmAudioSettings()
	{
		_audio.Sound("Reset").Play();
		PlayerPrefs.SetFloat("musicVolume", _musicSlider.GetValue());
		PlayerPrefs.SetFloat("vfxVolume", _vfxSlider.GetValue());
		PlayerPrefs.SetFloat("uiVolume", _uiSlider.GetValue());
	}

	public void ResetAudioSettings()
	{
		_audio.Sound("Reset").Play();
		_musicSlider.ResetValue();
		_vfxSlider.ResetValue();
		_uiSlider.ResetValue();
	}
}
