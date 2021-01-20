using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private GameObject _player;
    public event Action OnPlayerFound;


	void OnEnable()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _player = player;
        }
		OnPlayerFound?.Invoke();
    }

    void OnDisable()
    {
    }

    public GameObject GetPlayer()
    {
        if (_player != null)
        {
            return _player;
        }
        else
        {
            return null;
        }
    }
}
