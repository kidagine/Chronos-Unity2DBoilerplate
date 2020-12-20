
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private PlayerStatsUI _playerStatsUI = default;

    public PlayerStatsUI PlayerStatsUI { get { return _playerStatsUI; } private set { } }
}