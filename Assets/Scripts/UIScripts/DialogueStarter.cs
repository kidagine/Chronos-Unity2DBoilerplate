using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private DialogueSystem _dialogueSystem = default;
    [SerializeField] private YarnProgram _yarnScript = default;
    [SerializeField] private string _startNode = default;
    [SerializeField] private Trigger _trigger = default;
    [Header("Dialogue Text")]
    [SerializeField] private Color _textColor = Color.white;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float _textSpeed = 0.085f;
    [Header("Dialogue Audio")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float _volume = 1.0f;
    [Range(0.0f, 3.0f)]
    [SerializeField] private float _pitch = 1.0f;


    void Start()
	{

    }

	public void StartDialogue()
    {
        _dialogueSystem.SetDialogueAudio(_volume, _pitch);
        _dialogueSystem.SetDialogueText(_textColor, _textSpeed);
        _dialogueSystem.SetupDialogue(_yarnScript, _startNode, _trigger);
        _dialogueSystem.StartDialogue();
    }
}
