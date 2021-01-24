﻿using System;
using UnityEngine;

[Serializable]
public enum TagEnum { Player };

public class Tags : MonoBehaviour
{
	[SerializeField] private TagEnum _tagEnum = default;

	public TagEnum TagEnum { get { return _tagEnum; } private set { } }
}
