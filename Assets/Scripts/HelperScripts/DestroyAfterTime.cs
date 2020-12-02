using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float _destroyTime = default;


    void Start()
    {
        Destroy(gameObject, _destroyTime);
    }
}
