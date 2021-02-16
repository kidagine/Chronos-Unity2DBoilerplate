using UnityEngine;

public class SceneAdditiveLoader : MonoBehaviour
{
    [SerializeField] private Level _level = default;


    void Awake()
    {
        LevelManager.Instance.AddAdditiveLevel(_level);
    }

	void Start()
	{
        #if UNITY_EDITOR
        Printer.SetLoaded();
        #endif
    }
}
