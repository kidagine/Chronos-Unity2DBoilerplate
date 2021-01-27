﻿using System;
using UnityEngine;
using UnityEngine.Audio;

public class EntityAudio : MonoBehaviour
{
	[SerializeField] private AudioMixerGroup _audioMixerGroup = default;
	[SerializeField] private Sound[] _sounds = default;
	[SerializeField] private Sound3D[] _sounds3D = default;
	[SerializeField] private SoundGroup[] _soundGroups = default;
	[SerializeField] private SoundGroup3D[] _soundGroups3D = default;


	void Awake()
	{
		SetSounds();
		SetSounds3D();
		SetSoundGroups();
		SetSoundGroups3D();
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

	private void SetSounds3D()
	{
		foreach (Sound3D sound3D in _sounds3D)
		{
			sound3D.source = gameObject.AddComponent<AudioSource>();
			sound3D.source.clip = sound3D.clip;

			sound3D.source.volume = sound3D.volume;
			sound3D.source.pitch = sound3D.pitch;
			sound3D.source.loop = sound3D.loop;
			sound3D.source.playOnAwake = sound3D.playOnAwake;
			sound3D.source.outputAudioMixerGroup = _audioMixerGroup;
			sound3D.source.spatialBlend = 1.0f;
			sound3D.source.rolloffMode = AudioRolloffMode.Linear;
			sound3D.source.maxDistance = sound3D.maxDistance;
			sound3D.source.minDistance = sound3D.minDistance;
			if (sound3D.source.playOnAwake)
			{
				sound3D.source.Play();
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

	private void SetSoundGroups3D()
	{
		foreach (SoundGroup3D soundGroup3D in _soundGroups3D)
		{
			foreach (Sound3D sound3D in soundGroup3D.sounds)
			{
				sound3D.source = gameObject.AddComponent<AudioSource>();
				sound3D.source.clip = sound3D.clip;

				sound3D.source.volume = sound3D.volume;
				sound3D.source.pitch = sound3D.pitch;
				sound3D.source.loop = sound3D.loop;
				sound3D.source.playOnAwake = sound3D.playOnAwake;
				sound3D.source.outputAudioMixerGroup = _audioMixerGroup;
				if (sound3D.source.playOnAwake)
				{
					sound3D.source.Play();
				}
			}
		}
	}

	public Sound Sound(string name)
	{
		Sound sound = Array.Find(_sounds, s => s.name == name);
		return sound;
	}

	public Sound3D Sound3D(string name)
	{
		Sound3D sound3D = Array.Find(_sounds3D, s => s.name == name);
		return sound3D;
	}

	public SoundGroup SoundGroup(string name)
	{
		SoundGroup soundGroup = Array.Find(_soundGroups, s => s.name == name);
		return soundGroup;
	}
}