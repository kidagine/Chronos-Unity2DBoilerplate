using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    private PlayerController _playerController;

    public static GameManager Instance { get; private set; }
    public bool GamePauseState { get; private set; }

    public event Action OnGamePauseStateChange;


    void Awake()
    {
        CheckInstance();
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player)
        {
            _playerController = _player.GetComponent<PlayerController>();
        }
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
        if (GamePauseState)
        {
            _playerController.DeactivateInput();
            Time.timeScale = 0.0f;
        }
        else
        {
            _playerController.ActivateInput();
            Time.timeScale = 1.0f;
        }
        OnGamePauseStateChange?.Invoke();
    }

    public void SetPlayerControllerActivation(bool state)
    {
        if (state)
        {
            _playerController.ActivateInput();
        }
        else
        {
            _playerController.DeactivateInput();
        }
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
