using UnityEngine;

public class MusicInitializer : MonoBehaviour
{
	[SerializeField] private string _musicName = default;


	void Start()
	{
		SoundManager.Instance.SetMusic(_musicName);
	}
}
