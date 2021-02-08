using UnityEngine;

public class PlayerStats : MonoBehaviour, ISceneDataSerializer
{
	[Header("Stats")]
    public int health = 10;
	public float speed = 4;
	public float jumpImpulse = 5;
    public int jumpCount = 1;
	[HideInInspector] public int currentHealth;
	[HideInInspector] public float currentSpeed;
	[HideInInspector] public int currentJumpCount;


	void Awake()
	{
		LoadSceneData();
	}

	public void LoadSceneData()
	{
		Debug.Log(SceneDataCarrier.GetInt("PlayerCurrentHealth", 0));
		transform.position = new Vector2(SceneDataCarrier.GetFloat("PlayerPositionX", transform.position.x), SceneDataCarrier.GetFloat("PlayerPositionY", transform.position.y));
		health = SceneDataCarrier.GetInt("PlayerHealth", health);
		speed = SceneDataCarrier.GetFloat("PlayerSpeed", speed);
		jumpCount = SceneDataCarrier.GetInt("PlayerJumpCount", jumpCount);
		currentHealth = SceneDataCarrier.GetInt("PlayerCurrentHealth", health);
		currentSpeed = SceneDataCarrier.GetFloat("PlayerCurrentSpeed", speed);
		currentJumpCount = SceneDataCarrier.GetInt("PlayerCurrentJumpCount", jumpCount);
	}

	void OnDestroy()
	{
		SaveSceneData();
	}

	public void SaveSceneData()
	{
		SceneDataCarrier.SetInt("PlayerHealth", health);
		SceneDataCarrier.SetFloat("PlayerSpeed", speed);
		SceneDataCarrier.SetInt("PlayerJumpCount", jumpCount);
		SceneDataCarrier.SetInt("PlayerCurrentHealth", currentHealth);
		SceneDataCarrier.SetFloat("PlayerCurrentSpeed", currentSpeed);
		SceneDataCarrier.SetInt("PlayerCurrentJumpCount", currentJumpCount);
		SceneDataCarrier.SetFloat("PlayerPositionX", transform.position.x);
		SceneDataCarrier.SetFloat("PlayerPositionY", transform.position.y);
	}
}
