﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

	private static T _instance = null;

	public static bool IsAwake { get { return (_instance != null); } }

	/// <summary>
	/// gets the instance of this Singleton
	/// use this for all instance calls:
	/// MyClass.Instance.MyMethod();
	/// or make your public methods static
	/// and have them use Instance
	/// </summary>
	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = (T)FindObjectOfType(typeof(T));
				if (_instance == null)
				{

					string goName = typeof(T).ToString();

					GameObject go = GameObject.Find(goName);
					if (go == null)
					{
						go = new GameObject();
						go.name = goName;
					}

					_instance = go.AddComponent<T>();
				}
			}
			return _instance;
		}
	}

	/// <summary>
	/// for garbage collection
	/// </summary>
	public virtual void OnApplicationQuit()
	{
		// release reference on exit
		_instance = null;
	}

	// in your child class you can implement Awake()
	// and add any initialization code you want such as
	// DontDestroyOnLoad(go);
	// if you want this to persist across loads
	// or if you want to set a parent object with SetParent()

	/// <summary>
	/// parent this to another gameobject by string
	/// call from Awake if you so desire
	/// </summary>
	protected void SetParent(string parentGOName)
	{
		if (parentGOName != null)
		{
			GameObject parentGO = GameObject.Find(parentGOName);
			if (parentGO == null)
			{
				parentGO = new GameObject();
				parentGO.name = parentGOName;
			}
			this.transform.parent = parentGO.transform;
		}
	}

}