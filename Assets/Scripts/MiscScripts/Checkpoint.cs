using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private string _areaName = default;
    [SerializeField] private int _checkpointIndex = default;

    public string AreaName { get { return _areaName; } private set { } }
    public int CheckpointIndex { get { return _checkpointIndex; } private set { } }


	void Start()
	{
        CheckpointManager.Instance.AddCheckpoint(GetComponent<Checkpoint>());
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            //CheckpointManager.Instance.StoreCheckpoint(GetComponent<Checkpoint>());
        }
    }

    public Vector2 GetCheckpointPosition()
    {
        return transform.position;
    }
}
