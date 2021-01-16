using UnityEngine;

public class SingleInstance : MonoBehaviour
{
    public static SingleInstance Instance { get; set; }


    void Awake()
    {
        CheckInstance();
    }

    private void CheckInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
