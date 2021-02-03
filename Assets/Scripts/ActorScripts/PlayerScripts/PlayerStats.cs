using UnityEngine;

public class PlayerStats : MonoBehaviour
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
		currentHealth = health;
		currentSpeed = speed;
		currentJumpCount = jumpCount;
	}
}
