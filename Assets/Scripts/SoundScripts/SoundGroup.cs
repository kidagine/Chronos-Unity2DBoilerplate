
using System;

[Serializable]
public class SoundGroup
{
	public string name;
	public int lastPlayedSoundIndex;
	public Sound[] sounds;
}