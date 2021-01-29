using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IPushboxResponder
{
    [SerializeField] private Player _player = default;
    [SerializeField] private PlayerAnimator _playerAnimator = default;
    [SerializeField] private Rigidbody2D _rigidbody = default;
    [SerializeField] private EntityAudio _playerAudio = default;
    [SerializeField] private float _groundMoveSpeed = 5.0f;
    [SerializeField] private float _jumpImpulse = 5.0f;
    [SerializeField] private int _maxJumpCount = 1;
    private float _currentMoveSpeed;
    private int _jumpCount;

    public bool IsGrounded { get; private set; }
    public Vector2 MovementInput { private get; set; }


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
        if (_player.IsRecovered)
        {
            _rigidbody.velocity = new Vector2(MovementInput.x * _currentMoveSpeed, _rigidbody.velocity.y);
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
        if (_jumpCount < _maxJumpCount && _rigidbody.constraints != RigidbodyConstraints2D.FreezePosition)
        {
            _playerAudio.Sound("Jump").Play();
            _jumpCount++;
            _rigidbody.AddForce(new Vector2(0.0f, _jumpImpulse), ForceMode2D.Impulse);
            ObjectPoolingManager.Instance.Spawn("JumpSmoke", transform.position, Quaternion.identity);
            _playerAnimator.JumpAnimation();
        }
    }

	public void OnGrounded()
	{
        if (!IsGrounded)
        {
            _playerAudio.Sound("Landed").Play();
            _currentMoveSpeed = _groundMoveSpeed;
            IsGrounded = true;
            _jumpCount = 0;
            ObjectPoolingManager.Instance.Spawn("LandSmoke", transform.position, Quaternion.identity);
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
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else
        {
            _rigidbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
