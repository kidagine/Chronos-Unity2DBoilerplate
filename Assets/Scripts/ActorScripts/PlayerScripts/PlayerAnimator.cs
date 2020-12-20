using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator = default;


    public void IdleAnimation()
    {
        _animator.SetBool("IsMoving", false);
    }

    public void WalkForwardAnimation()
    {
        _animator.SetBool("IsMoving", true);
        _animator.SetBool("IsMovingForward", true);
    }

    public void WalkBackwardAnimation()
    {
        _animator.SetBool("IsMoving", true);
        _animator.SetBool("IsMovingForward", false);
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

    public void HurtAnimation()
    {
        _animator.SetTrigger("Hurt");
    }

    public void DeathAnimation()
    {
        _animator.SetTrigger("Dead");
    }
}
