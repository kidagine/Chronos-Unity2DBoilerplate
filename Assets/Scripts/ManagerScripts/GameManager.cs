using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _player;


	public GameObject GetPlayer()
    {
        return _player;
    }
}
