
using System;

[Serializable]
public struct SoundGroup
{
	public string name;
	public int lastPlayedSoundIndex;
	public Sound[] sounds;
}