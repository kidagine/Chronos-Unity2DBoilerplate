using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAdditiveLoader : MonoBehaviour
{
    [SerializeField] private Levels _level = default;


    void Awake()
    {
        LevelManager.Instance.AddAdditiveScene(_level);
    }
}
