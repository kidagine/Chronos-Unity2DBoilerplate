using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _player;

    public static GameManager Instance { get; private set; }


    void Awake()
    {
        CheckInstance();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        //_player.transform.position = GlobalSettings.PlayerPosition;
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

    public GameObject GetPlayer()
    {
        return _player;
    }

    public int GetSaveSlotIndex()
    {
        return 2;
    }

    public void RestartToCheckpoint()
    {

    }
}
