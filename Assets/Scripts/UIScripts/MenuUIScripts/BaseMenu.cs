using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BaseMenu : MonoBehaviour	
{
	[SerializeField] private Selectable _startingOption = default;


	void OnEnable()
	{
		if (_startingOption)
		{
			StartCoroutine(ActivateCoroutine());
		}
	}

	IEnumerator ActivateCoroutine()
	{
		yield return null;
		_startingOption.Select();	
	}

	public void OpenMenuHideCurrent(BaseMenu menu)
	{
		gameObject.SetActive(false);
		menu.gameObject.SetActive(true);
	}

	public void OpenMenu(BaseMenu menu)
	{
		menu.gameObject.SetActive(true);
	}
}