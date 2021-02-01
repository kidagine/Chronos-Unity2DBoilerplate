using System;
using UnityEngine;

[Serializable]
public enum ControlSchemeEnum { KeyboardMouse, Xbox, Dualshock };

public class ControlSchemes : MonoBehaviour
{
	[SerializeField] private ControlSchemeEnum _controlSchemeEnum = default;

	public ControlSchemeEnum ControlSchemesEnums { get { return _controlSchemeEnum; } private set { } }
}
