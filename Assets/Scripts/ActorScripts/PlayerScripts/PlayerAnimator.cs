using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;


	void Awake()
	{
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void IdleAnimation()
    {
        _animator.SetBool("IsMoving", false);
    }

    public void RunningAnimation()
    {
        _animator.SetBool("IsMoving", true);
    }

    public void SetVerticalVelocity(float value)
    {
        _animator.SetFloat("VelocityY", value);
    }

    public void CrouchAnimation()
    {
        _animator.SetBool("IsCrouching", true);
    }

    public void StandUpAnimation()
    {
        _animator.SetBool("IsCrouching", false);
    }

    public void JumpAnimation()
    {
        _animator.SetTrigger("Jump");
    }

    public void GroundedAnimation()
    {
        _animator.SetBool("IsGrounded", true);
    }

    public void AirAnimation()
    {
        _animator.SetBool("IsGrounded", false);
    }

    public void AttackAnimation()
    {
        _animator.SetTrigger("Attack");
    }

    public void CrouchAttackAnimation()
    {
        _animator.SetTrigger("CrouchAttack");
    }

    public void HurtAnimation()
    {
        _animator.SetTrigger("Hurt");
    }

    public void DeathAnimation()
    {
        _animator.SetTrigger("Dead");
    }

    public void FlipSprite(bool state)
    {
        _spriteRenderer.flipX = state;
    }

    public void FlipBody(bool state)
    {
        float flipValue = Mathf.Abs(transform.parent.localScale.x);
        if (state)
        {
            flipValue *= -1;
        }
        else
        {
            flipValue *= 1;
        }
        transform.parent.localScale = new Vector3(flipValue, transform.parent.localScale.y, transform.parent.localScale.z);
    }
}
