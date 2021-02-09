using UnityEngine;

public class SceneAdditiveLoader : MonoBehaviour
{
    [SerializeField] private Levels _level = default;


    void Awake()
    {
        LevelManager.Instance.AddAdditiveScene(_level);
    }

	void Start()
	{
        #if UNITY_EDITOR
        Printer.SetLoaded();
        #endif
    }
}
