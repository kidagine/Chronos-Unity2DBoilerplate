
using UnityEngine;
using Yarn.Unity;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private PlayerStatsUI _playerStatsUI = default;
    [SerializeField] private PauseMenu _playerPauseMenuUI = default;
    [SerializeField] private DialogueUI _playerDialogueUI = default;

    public PlayerStatsUI PlayerStatsUI { get { return _playerStatsUI; } private set { } }
    public PauseMenu PlayerPauseMenuUI { get { return _playerPauseMenuUI; } private set { } }
    public DialogueUI PlayerDialogueUI { get { return _playerDialogueUI; } private set { } }

}