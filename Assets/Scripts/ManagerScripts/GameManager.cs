using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    public event Action OnPlayerFound;
    public event Action OnGamePauseStateChange;
    public static GameManager Instance { get; private set; }

    public bool GamePauseState { get; private set; }


    void Awake()
    {
        CheckInstance();
        _player = GameObject.FindGameObjectWithTag("Player");
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

    public void SetGamePauseState(bool state)
    {
        GamePauseState = state;
        OnGamePauseStateChange?.Invoke();
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
