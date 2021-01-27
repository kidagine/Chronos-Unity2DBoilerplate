using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioMixer _mainAudioMixer = default;
    [SerializeField] private EntityAudio _mainAudio = default;
    private float _cachedMasterVolume;
    private float lerpRatio = 0.0f;
    private float startLerpValue;
    private float endLerpValue;
    private bool isLerping;


	void Start()
	{
        _cachedMasterVolume = GetMasterVolume();
	}

	void Update()
	{
        if (isLerping)
        {
            float value = Mathf.Lerp(startLerpValue, endLerpValue, lerpRatio);
            lerpRatio += 0.2f * Time.deltaTime;
            if (lerpRatio > 1.0f)
            {
                isLerping = false;
                SetMasterVolume(endLerpValue, false);
            }
            SetMasterVolume(value, false);
        }
    }

    public void SetMusic(string name)
    {
        _mainAudio.Sound(name).Play();
    }

	public void FadeInMasterVolume()
    {
        startLerpValue = 0.00001f;
        endLerpValue = 1.0f;
        lerpRatio = 0.0f;
        isLerping = true;
    }

    public void FadeOutMasterVolume()
    {
        startLerpValue = 1.0f;
        endLerpValue = 0.00001f;
        lerpRatio = 0.0f;
        isLerping = true;
    }

    public void SetMasterVolume(float value, bool isCaching = true)
    {
        if (isCaching)
        {
            _cachedMasterVolume = GetMasterVolume();
        }
        _mainAudioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }

    private float GetMasterVolume()
    {
		_mainAudioMixer.GetFloat("MasterVolume", out float masterVolume);
		return masterVolume;
    }

    public void SetMasterVolumeToCached()
    {
        SetMasterVolume(_cachedMasterVolume);
    }

    public void SetMusicVolume(float value)
    {
        _mainAudioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    public void SetVFXVolume(float value)
    {
        _mainAudioMixer.SetFloat("VFXVolume", Mathf.Log10(value) * 20);
    }

    public void SetUIVolume(float value)
    {
        _mainAudioMixer.SetFloat("UIVolume", Mathf.Log10(value) * 20);
    }
}
