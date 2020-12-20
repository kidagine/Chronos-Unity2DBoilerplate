using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _playerAnimator = default;
    [SerializeField] private Rigidbody2D _rigidbody = default;
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _jumpImpulse = 5.0f;
    private bool _lockMovement;

    public Vector2 MovementInput { private get; set; }


    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (!_lockMovement)
        {
            _rigidbody.velocity = new Vector2(MovementInput.x * _moveSpeed, _rigidbody.velocity.y);
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
        _rigidbody.AddForce(new Vector2(0.0f, _jumpImpulse), ForceMode2D.Impulse);
        _playerAnimator.JumpAnimation();
    }

    public void CrouchAction()
    {
        _lockMovement = true;
        _rigidbody.velocity = Vector2.zero;
        _playerAnimator.CrouchAnimation();
    }

    public void StandUpAction()
    {
        _lockMovement = false;
        _playerAnimator.StandUpAnimation();
    }

	private void OnCollisionEnter2D(Collision2D other)
	{
        Debug.Log(other.contacts[0].normal);
	}
}
