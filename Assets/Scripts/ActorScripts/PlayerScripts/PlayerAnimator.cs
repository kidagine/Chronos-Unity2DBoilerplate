using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
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
}
