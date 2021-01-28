using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : Singleton<ObjectPoolingManager>
{
	[SerializeField] private List<ObjectPool> _objectPools;
	[SerializeField] private Dictionary<string, Queue<GameObject>> _objectPoolDictionary = new Dictionary<string, Queue<GameObject>>();


	void Start()
	{
		foreach (ObjectPool objectPool in _objectPools)
		{
			Queue<GameObject> objectPoolQueue = new Queue<GameObject>();
			for (int i = 0; i < objectPool.size; i++)
			{
				GameObject poolObject = Instantiate(objectPool.prefab, transform);
				poolObject.SetActive(false);
				objectPoolQueue.Enqueue(poolObject);
			}
			_objectPoolDictionary.Add(objectPool.name, objectPoolQueue);
		}
	}

	public GameObject Spawn(string name, Vector3 position = default, Quaternion rotation = default)
	{
		if (_objectPoolDictionary.ContainsKey(name))
		{
			GameObject poolObject = _objectPoolDictionary[name].Dequeue();
			poolObject.transform.position = position;
			poolObject.transform.rotation = rotation;
			poolObject.SetActive(true);
			_objectPoolDictionary[name].Enqueue(poolObject);
			return poolObject;
		}
		else
		{
			Debug.LogError($"Pool with name {name} doesn't exist.");
			return null;
		}
	}
}
