using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameObject _player;


    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }


    public GameObject GetPlayer()
    {
        return _player;
    }
}
