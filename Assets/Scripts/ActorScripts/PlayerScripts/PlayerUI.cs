
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private PlayerStatsUI _playerStatsUI = default;
    [SerializeField] private PlayerPauseMenu _playerPauseMenuUI = default;

    public PlayerStatsUI PlayerStatsUI { get { return _playerStatsUI; } private set { } }
    public PlayerPauseMenu PlayerPauseMenuUI { get { return _playerPauseMenuUI; } private set { } }
}