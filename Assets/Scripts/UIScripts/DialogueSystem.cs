using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using Yarn.Unity;

[RequireComponent(typeof(DialogueRunner))]
[RequireComponent(typeof(DialogueUI))]
[RequireComponent(typeof(EntityAudio))]
public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueText = default;
    private DialogueRunner _dialogueRunner = default;
    private DialogueUI _dialogueUI = default;
    private EntityAudio _audio = default;
    private PlayerController _playerController = default;


    void Awake()
    {
        _dialogueRunner = GetComponent<DialogueRunner>();
        _dialogueUI = GetComponent<DialogueUI>();
        _audio = GetComponent<EntityAudio>();
    }

	void Start()
	{
        _playerController = GameManager.Instance.GetPlayer().GetComponent<PlayerController>(); ;
	}

	public void PlayDialogueTypingSound()
    {
        _audio.Sound("Typing").Play();
    }

    public void SetDialogueAudio(float volume, float pitch)
    {
        Sound typingSound = _audio.Sound("Typing");
        typingSound.source.volume = volume;
        typingSound.source.pitch = pitch;
    }

    public void SetDialogueText(Color textColor, float textSpeed)
    {
        _dialogueText.color = textColor;
        _dialogueUI.textSpeed = textSpeed;
    }

    public void SetupDialogue(YarnProgram yarnScript, string startNode, Trigger trigger)
    {
        //_dialogueRunner.textLanguage = LocalizationSettings.SelectedLocale.Identifier.Code;
        _dialogueUI.onDialogueEnd.RemoveAllListeners();
        _dialogueUI.onDialogueEnd.AddListener(trigger.ResetTrigger);
        _dialogueRunner.startNode = startNode;
        if (!_dialogueRunner.NodeExists(startNode))
        {
            _dialogueRunner.Add(yarnScript);
        }
    }

    public void StartDialogue()
    {
        _dialogueRunner.StartDialogue();
    }

    public void SwitchPlayerToDialogue()
    {
        _playerController.SwitchToDialogueActionMap();
    }

    public void SwitchPlayerToGameplay()
    {
        _playerController.SwitchToGameplayActionMap();
    }
}
