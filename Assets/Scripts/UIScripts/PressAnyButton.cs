using UnityEngine;

[RequireComponent(typeof(Level))]
public class PressAnyButton : MonoBehaviour
{
    private Level _level;
    private bool _keyHold;


	void Awake()
	{
		_level = GetComponent<Level>();	
	}

	void Update()
    {
        if (Input.anyKey)
        {
            _keyHold = true;
        }

        if (!Input.anyKey && _keyHold)
        {
            LevelManager.Instance.GoToLevel(_level);
        }
    }
}
