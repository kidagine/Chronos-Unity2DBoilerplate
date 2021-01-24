using System;
using UnityEngine;

[Serializable]
public enum LayerMaskEnum { Ground, Hurtbox, Player };

public class LayerMasks : MonoBehaviour
{
	[SerializeField] private LayerMaskEnum _layerMasksEnum = default;

	public LayerMaskEnum LayerMasksEnum { get { return _layerMasksEnum; } private set { } }
}
