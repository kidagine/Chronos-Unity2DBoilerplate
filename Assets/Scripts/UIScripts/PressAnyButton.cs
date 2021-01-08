using UnityEngine;

public class PressAnyButton : MonoBehaviour
{
    [SerializeField] private Levels _levels = default;


    void Update()
    {
        if (Input.anyKeyDown)
        {
            LevelManager.Instance.GoToLevel(_levels);
        }
    }
}
