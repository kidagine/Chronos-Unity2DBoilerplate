using UnityEngine;

[RequireComponent(typeof(Level))]
public class SceneAdditiveLoader : MonoBehaviour
{
    private Level _level;


    void Awake()
    {
        _level = GetComponent<Level>();
        LevelManager.Instance.AddAdditiveLevel(_level);
    }

	void Start()
	{
        #if UNITY_EDITOR
        Printer.SetLoaded();
        #endif
    }
}
