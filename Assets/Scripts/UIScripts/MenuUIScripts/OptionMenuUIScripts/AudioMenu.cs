using UnityEngine;

[RequireComponent(typeof(Audio))]
public class AudioMenu : BaseMenu, IOptionMenu
{
	[SerializeField] private BaseSlider _musicSlider = default;
	[SerializeField] private BaseSlider _vfxSlider = default;
	[SerializeField] private BaseSlider _uiSlider = default;
	private Audio _audio;


	void Awake()
	{
		_audio = GetComponent<Audio>();
	}

	public void SetMusicVolume(float value)
	{
		_musicSlider.OnValueChange();
		SoundManager.Instance.SetMusicVolume(value);
	}

	public void SetVFXVolume(float value)
	{
		_vfxSlider.OnValueChange();
		SoundManager.Instance.SetVFXVolume(value);
	}

	public void SetUIVolume(float value)
	{
		_uiSlider.OnValueChange();
		SoundManager.Instance.SetUIVolume(value);
	}

	public void InitializePreferences()
	{
		_musicSlider.SetValue(PlayerPrefs.GetFloat("musicVolume", _musicSlider.DefaultValue));
		_vfxSlider.SetValue(PlayerPrefs.GetFloat("vfxVolume", _musicSlider.DefaultValue));
		_uiSlider.SetValue(PlayerPrefs.GetFloat("uiVolume", _musicSlider.DefaultValue));
	}

	public void ConfirmSettings()
	{
		_audio.Sound("Confirm").Play();
		PlayerPrefs.SetFloat("musicVolume", _musicSlider.GetValue());
		PlayerPrefs.SetFloat("vfxVolume", _vfxSlider.GetValue());
		PlayerPrefs.SetFloat("uiVolume", _uiSlider.GetValue());
	}

	public void ResetSettings()
	{
		_audio.Sound("Reset").Play();
		_musicSlider.ResetValue();
		_vfxSlider.ResetValue();
		_uiSlider.ResetValue();
	}

	void OnDisable()
	{
		InitializePreferences();
	}
}
