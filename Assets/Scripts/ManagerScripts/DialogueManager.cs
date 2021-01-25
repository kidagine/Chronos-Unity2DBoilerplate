using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
	public void StartDialogue()
	{
		DialogueRunner S = new DialogueRunner();
		S.StartDialogue();
	}
}
