using UnityEngine;

[RequireComponent(typeof(Level))]
public class SceneAdditiveLoader : MonoBehaviour
{
    [SerializeField] private Level[] _levels = default;
    [SerializeField] private Level[] _debugLevels = default;


    void Awake()
    {
		foreach (Level level in _levels)
		{
            LevelManager.Instance.AddAdditiveLevel(level);
        }
#if UNITY_EDITOR
        foreach (Level level in _debugLevels)
        {
            LevelManager.Instance.AddAdditiveLevel(level);
        }
#endif
    }

#if UNITY_EDITOR
    void Start()
	{
        Printer.SetLoaded();
    }
#endif
}
