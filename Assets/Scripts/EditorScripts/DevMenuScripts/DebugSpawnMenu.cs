using UnityEngine;
using UnityEngine.UI;

public class DebugSpawnMenu : MonoBehaviour, ISubMenu
{
	[SerializeField] private Selectable _startingOption = default;
	private readonly float _distanceFromSpawn = 1.5f;


	public void Spawn(GameObject objectToSpawn)
	{
		GameObject player = GameManager.Instance.GetPlayer();
		if (player != null)
		{
			Vector2 spawnPosition = new Vector2(player.transform.position.x, player.transform.position.y + 3.0f);
			Instantiate(objectToSpawn, Random.insideUnitCircle * _distanceFromSpawn + spawnPosition, Quaternion.identity);
		}
		else
		{
			Printer.Log("Player not found, spawning in center", duration: 2.0f, flipToRight: true);
			Instantiate(objectToSpawn, Vector2.zero, Quaternion.identity);
		}
	}

	public void Activate()
	{
		_startingOption.Select();
	}
}
