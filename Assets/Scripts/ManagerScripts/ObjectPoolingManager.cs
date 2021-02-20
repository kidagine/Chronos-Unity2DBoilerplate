using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
	[SerializeField] private List<ObjectPool> _objectPools;
	[SerializeField] private Dictionary<GameObject, Queue<GameObject>> _objectPoolDictionary = new Dictionary<GameObject, Queue<GameObject>>();

	public static ObjectPoolingManager Instance { get; private set; }


	void Awake()
	{
		CheckInstance();
	}

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
			_objectPoolDictionary.Add(objectPool.prefab, objectPoolQueue);
		}
	}

	private void CheckInstance()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	public GameObject Spawn(GameObject newPoolObject, Vector3 position = default, Quaternion rotation = default)
	{
		if (_objectPoolDictionary.ContainsKey(newPoolObject))
		{
			GameObject poolObject = _objectPoolDictionary[newPoolObject].Dequeue();
			poolObject.transform.position = position;
			poolObject.transform.rotation = rotation;
			poolObject.SetActive(true);
			_objectPoolDictionary[newPoolObject].Enqueue(poolObject);
			return poolObject;
		}
		else
		{
			Debug.LogError($"Pool with name {newPoolObject.name} doesn't exist.");
			return null;
		}
	}

}
