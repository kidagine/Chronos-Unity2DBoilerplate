using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _player;
    public event Action OnPlayerFound;

    private void Awake()
	{
        //CheckInstance();

    }
	void OnEnable()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        LevelManager.Instance.onLevelLoaded += OnLevelLoaded;
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        _player = GameObject.FindGameObjectWithTag("Player");
		OnPlayerFound?.Invoke();
    }

    void OnDisable()
    {
        LevelManager.Instance.onLevelLoaded -= OnLevelLoaded;
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
