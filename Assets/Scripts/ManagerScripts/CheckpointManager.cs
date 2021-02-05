using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : Singleton<CheckpointManager>
{
    private readonly List<Checkpoint> _checkpoints = new List<Checkpoint>();
	private Transform _player;
	private int _currentCheckpointIndex;


	void Start()
	{
		_player = GameManager.Instance.GetPlayer().transform;
	}

	public void AddCheckpoint(Checkpoint checkpoint)
    {
        _checkpoints.Add(checkpoint);
    }

	public void GoToNextCheckpoint()
	{
		int nextCheckpointIndex = _currentCheckpointIndex + 1;
		if (nextCheckpointIndex <= _checkpoints.Count - 1) 
		{
			Checkpoint checkpoint = _checkpoints[nextCheckpointIndex];
			_player.transform.position = checkpoint.GetCheckpointPosition();
			_currentCheckpointIndex = nextCheckpointIndex;
		}
		else
		{
			Checkpoint checkpoint = _checkpoints[0];
			_player.transform.position = checkpoint.GetCheckpointPosition();
			_currentCheckpointIndex = 0;
		}
	}

	public void GoToPreviousCheckpoint()
	{
		int previousCheckpointIndex = _currentCheckpointIndex - 1;
		if (previousCheckpointIndex >= 0)
		{
			Checkpoint checkpoint = _checkpoints[previousCheckpointIndex];
			_player.transform.position = checkpoint.GetCheckpointPosition();
			_currentCheckpointIndex = previousCheckpointIndex;
		}
		else
		{
			Checkpoint checkpoint = _checkpoints[_checkpoints.Count - 1];
			_player.transform.position = checkpoint.GetCheckpointPosition();
			_currentCheckpointIndex = _checkpoints.Count - 1;
		}
	}
}
