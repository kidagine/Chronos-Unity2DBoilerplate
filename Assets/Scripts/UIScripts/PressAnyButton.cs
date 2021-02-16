using UnityEngine;

[RequireComponent(typeof(Level))]
public class PressAnyButton : MonoBehaviour
{
    private Level _level;


	void Awake()
	{
		_level = GetComponent<Level>();	
	}

	void Start()
	{
        SoundManager.Instance.SetMusic("slip");	
	}

	void Update()
    {
        if (Input.anyKeyDown)
        {
            LevelManager.Instance.GoToLevel(_level);
        }
    }
}
