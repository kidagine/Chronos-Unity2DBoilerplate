using UnityEngine;

public class SceneAdditiveLoader : MonoBehaviour
{
    [SerializeField] private Levels _level = default;


    void Awake()
    {
        LevelManager.Instance.AddAdditiveScene(_level);
        #if UNITY_EDITOR
        LevelManager.Instance.OnAdditiveSceneLoaded += Printer.SetLoaded;
        #endif
    }
}
