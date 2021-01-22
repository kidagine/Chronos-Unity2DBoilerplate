using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    public event Action OnPlayerFound;

    public static GameManager Instance { get; private set; }


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
