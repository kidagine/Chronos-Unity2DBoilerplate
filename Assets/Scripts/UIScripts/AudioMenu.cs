using UnityEngine;
using UnityEngine.UI;

public class AudioMenu : MonoBehaviour, ISubMenu
{
	[SerializeField] private Selectable _startingOption = default;
	[SerializeField] private BaseSlider _musicSlider = default;
	[SerializeField] private BaseSlider _vfxSlider = default;
	[SerializeField] private BaseSlider _uiSlider = default;
	private EntityAudio _audio;


	void Awake()
	{
		_audio = GetComponent<EntityAudio>();
	}

	public void OpenMenu(GameObject menu)
	{
		gameObject.SetActive(false);
		if (menu.TryGetComponent(out ISubMenu subMenu))
		{
			subMenu.Activate();
		}
	}

	public void Activate()
	{
		gameObject.SetActive(true);
		_startingOption.Select();
	}

	public void ResetAudioSettings()
	{
		_audio.Sound("Reset").Play();
		_musicSlider.ResetValue();
		_vfxSlider.ResetValue();
		_uiSlider.ResetValue();
	}
}
