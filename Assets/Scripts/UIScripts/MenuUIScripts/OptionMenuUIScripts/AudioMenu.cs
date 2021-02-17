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
		InitializePreferences();
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
		_musicSlider.SetValue(PreferenceInitializer.Instance.MusicVolume);
		_vfxSlider.SetValue(PreferenceInitializer.Instance.VFXVolume);
		_uiSlider.SetValue(PreferenceInitializer.Instance.UIVolume);
	}

	public void ConfirmSettings()
	{
		_audio.Sound("Confirm").Play();
		PreferenceInitializer.Instance.SetMusicVolume(_musicSlider.GetValue());
		PreferenceInitializer.Instance.SetVFXVolume(_vfxSlider.GetValue());
		PreferenceInitializer.Instance.SetUIVolume(_uiSlider.GetValue());
	}

	public void ResetSettings()
	{
		_audio.Sound("Reset").Play();
		Debug.Log(PreferenceInitializer.Instance.DefaultMusicVolume);
		_musicSlider.SetValue(PreferenceInitializer.Instance.DefaultMusicVolume);
		_vfxSlider.SetValue(PreferenceInitializer.Instance.DefaultVFXVolume);
		_uiSlider.SetValue(PreferenceInitializer.Instance.DefaultUIVolume);
	}

	void OnDisable()
	{
		InitializePreferences();
	}
}
