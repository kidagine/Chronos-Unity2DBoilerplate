using System;
using UnityEngine;

[Serializable]
public enum PromptsEnum { Ground, Hurtbox };

public class Prompts : MonoBehaviour
{
	[SerializeField] private PromptsEnum _promptsEnum = default;

	public PromptsEnum PromptsEnum { get { return _promptsEnum; } private set { } }
}
