using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IPushboxResponder
{
    [SerializeField] private PlayerAnimator _playerAnimator = default;
    [SerializeField] private Rigidbody2D _rigidbody = default;
    [SerializeField] private float _groundMoveSpeed = 5.0f;
    [SerializeField] private float _airMoveSpeed = 7.0f;
    [SerializeField] private float _jumpImpulse = 5.0f;
    [SerializeField] private int _maxJumpCount = 1;
    private float _currentMoveSpeed;
    private int _jumpCount;

    public bool IsStunned { get; set; }
    public bool IsGrounded { get; private set; }
    public bool IsCrouched { get; private set; }
    public Vector2 MovementInput { private get; set; }


    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (!IsCrouched && !IsStunned)
        {
            _rigidbody.velocity = new Vector2(MovementInput.x * _currentMoveSpeed   , _rigidbody.velocity.y);
            if (_rigidbody.velocity != Vector2.zero)
            {
                if (_rigidbody.velocity.x > 0.0f)
                {
                    _playerAnimator.WalkForwardAnimation();
                }
                else
                {
                    _playerAnimator.WalkBackwardAnimation();
                }
            }
            else
            {
                _playerAnimator.IdleAnimation();
            }
        }
    }

    public void JumpAction()
    {
        if (_jumpCount < _maxJumpCount && _rigidbody.constraints != RigidbodyConstraints2D.FreezePosition)
        {
            _jumpCount++;
            _rigidbody.AddForce(new Vector2(0.0f, _jumpImpulse), ForceMode2D.Impulse);
            _playerAnimator.JumpAnimation();
        }
    }

    public void CrouchAction()
    {
        if (IsGrounded)
        {
            IsCrouched = true;
            _rigidbody.velocity = Vector2.zero;
            _playerAnimator.CrouchAnimation();
        }
    }

    public void StandUpAction()
    {
        IsCrouched = false;
        _playerAnimator.StandUpAnimation();
    }

	public void OnGrounded()
	{
        if (!IsGrounded)
        {
            _currentMoveSpeed = _groundMoveSpeed;
            IsGrounded = true;
            _jumpCount = 0;
            _playerAnimator.GroundedAnimation();
        }

	}

    public void OnAir()
    {
        if (IsGrounded)
        {
            _currentMoveSpeed = _airMoveSpeed;
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
