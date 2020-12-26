using System;
using UnityEngine;

[Serializable]
public enum LayerMasksEnum { Ground, Hurtbox };

public class LayerMasks : MonoBehaviour
{
	[SerializeField] private LayerMasksEnum _layerMasksEnum = default;

	public LayerMasksEnum LayerMasksEnum { get { return _layerMasksEnum; } private set { } }
}
