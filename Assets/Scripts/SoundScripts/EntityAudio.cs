using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class EntityAudio : MonoBehaviour
{
	[SerializeField] private AudioMixerGroup _audioMixerGroup = default;
	[SerializeField] private Sound[] _sounds = default;
	[SerializeField] private SoundGroup[] _soundGroups = default;
	private Sound _previousRandomSound;


	void Awake()
	{
		SetSounds();
		SetSoundGroups();
	}

	private void SetSounds()
	{
		foreach (Sound sound in _sounds)
		{
			sound.source = gameObject.AddComponent<AudioSource>();
			sound.source.clip = sound.clip;

			sound.source.volume = sound.volume;
			sound.source.pitch = sound.pitch;
			sound.source.loop = sound.loop;
			sound.source.playOnAwake = sound.playOnAwake;
			sound.source.outputAudioMixerGroup = _audioMixerGroup;
			if (sound.source.playOnAwake)
			{
				sound.source.Play();
			}
		}
	}

	private void SetSoundGroups()
	{
		foreach (SoundGroup soundGroup in _soundGroups)
		{
			foreach (Sound sound in soundGroup.sounds)
			{
				sound.source = gameObject.AddComponent<AudioSource>();
				sound.source.clip = sound.clip;

				sound.source.volume = sound.volume;
				sound.source.pitch = sound.pitch;
				sound.source.loop = sound.loop;
				sound.source.playOnAwake = sound.playOnAwake;
				sound.source.outputAudioMixerGroup = _audioMixerGroup;
				if (sound.source.playOnAwake)
				{
					sound.source.Play();
				}
			}
		}
	}

	public void Play(string name)
	{
		Sound sound = Array.Find(_sounds, s => s.name == name);
		sound.source.Play();
	}

	public void Stop(string name)
	{
		Sound sound = Array.Find(_sounds, s => s.name == name);
		sound.source.Stop();
	}

	public bool IsPlaying(string name)
	{
		Sound sound = Array.Find(_sounds, s => s.name == name);
		return sound.source.isPlaying;
	}

	public void PlaySoundsInSequence(string name)
	{
		SoundGroup soundGroup = Array.Find(_soundGroups, sg => sg.name == name);
		int index = soundGroup.lastPlayedSoundIndex;
		Printer.Log(index);
		soundGroup.lastPlayedSoundIndex = 3;
		index = soundGroup.lastPlayedSoundIndex;
		Printer.Log(index);

	}

	public void PlayRandomFromSoundGroup(string name)
	{
		SoundGroup soundGroup = Array.Find(_soundGroups, sg => sg.name == name);
		Sound randomSound = soundGroup.sounds[UnityEngine.Random.Range(0, soundGroup.sounds.Length)];
		if (randomSound != _previousRandomSound)
		{
			_previousRandomSound = randomSound;
			randomSound.source.Play();
		}
		else
		{
			PlayRandomFromSoundGroup(name);
		}
	}

	public void FadeOut(string name)
	{
		Sound sound = Array.Find(_sounds, s => s.name == name);
		StartCoroutine(FadeOutCoroutine(sound));
	}

	IEnumerator FadeOutCoroutine(Sound sound)
	{
		sound.volume = 1;
		sound.loop = false;

		bool isVolumeLowered = false;
		while (!isVolumeLowered)
		{
			sound.source.volume -= 0.04f;
			if (sound.source.volume <= 0.0f)
			{
				isVolumeLowered = true;
			}
			yield return new WaitForSeconds(0.05f);
		}
		sound.source.Stop();
	}
}