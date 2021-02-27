using UnityEngine;

[RequireComponent(typeof(Audio))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerMovement : MonoBehaviour, IPushboxResponder
{
    [SerializeField] private PlayerAnimator _playerAnimator = default;
    [Header("Prefabs")]
    [SerializeField] private GameObject _jumpSmokePrefab = default;
    [SerializeField] private GameObject _landSmokePrefab = default;
    private Audio _audio;
    private Rigidbody2D _rigidbody;
    private PlayerStats _playerStats;

	public bool IsMovementLocked { get; private set; }
	public bool IsGrounded { get; private set; }
    public Vector2 MovementInput { private get; set; }


    void Awake()
    {
        _audio = GetComponent<Audio>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        HandleSpriteFlip();
        _playerAnimator.SetVerticalVelocity(_rigidbody.velocity.y); 
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (!IsMovementLocked)
        {
            _rigidbody.velocity = new Vector2(MovementInput.x * _playerStats.currentSpeed, _rigidbody.velocity.y);
            if (_rigidbody.velocity != Vector2.zero && MovementInput.x != 0.0f)
            {
                _playerAnimator.RunningAnimation();
            }
            else
            {
                _playerAnimator.IdleAnimation();
            }
        }
    }

    private void HandleSpriteFlip()
    {
        if (_rigidbody.constraints != RigidbodyConstraints2D.FreezePosition)
        {
            if (MovementInput.x > 0.0f)
            {
                _playerAnimator.FlipBody(false);
            }
            else if (MovementInput.x < 0.0f)
            {
                _playerAnimator.FlipBody(true);
            }
        }
    }

    public void JumpAction()
    {
        if (_playerStats.currentJumpCount < _playerStats.jumpCount && _rigidbody.constraints != RigidbodyConstraints2D.FreezePosition)
        {
            _audio.Sound("Jump").Play();
            _playerStats.currentJumpCount++;
            _rigidbody.AddForce(new Vector2(0.0f, _playerStats.jumpImpulse), ForceMode2D.Impulse);
            ObjectPoolingManager.Instance.Spawn(_jumpSmokePrefab, transform.position, Quaternion.identity);
            _playerAnimator.JumpAnimation();
        }
    }

	public void OnGrounded()
	{
        if (!IsGrounded)
        {
            _audio.Sound("Landed").Play();
            IsGrounded = true;
            _playerStats.currentJumpCount = 0;
            ObjectPoolingManager.Instance.Spawn(_landSmokePrefab, transform.position, Quaternion.identity);
            _playerAnimator.GroundedAnimation();
        }   
	}

    public void OnAir()
    {
        if (IsGrounded)
        {
            IsGrounded = false;
            _playerAnimator.AirAnimation();
        }
    }

    public void SetMovementLock(bool state)
    {    
        if (state)
        {
            IsMovementLocked = true;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else
        {
            IsMovementLocked = false;
            _rigidbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public void Knockback(Vector2 knockbackDirection, float knockbackForce)
    {
        _rigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }
}
