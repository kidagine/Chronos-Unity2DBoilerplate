using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BaseMenu : MonoBehaviour, ISubMenu
{
	[SerializeField] private Selectable _startingOption = default;


	void OnEnable()
	{
		StartCoroutine(ActivateCoroutine());
	}

	IEnumerator ActivateCoroutine()
	{
		yield return null;
		_startingOption.Select();
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
}