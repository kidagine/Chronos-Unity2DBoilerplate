using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	[Header("Stats")]
    [SerializeField] private int _health = 10;
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _jumpImpulse = default;
    [SerializeField] private int _jumpCount = 1;
	[Header("Components")]
	[SerializeField] private Player _player = default;
	[SerializeField] private PlayerMovement _playerMovement = default;

	public int Health { get { return _health; } set { _health = value; } }


	void Awake()
	{
			
	}
}
