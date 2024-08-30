using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            JumpAnimation(false);
        }
    }

    public void MoveAnimation()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }
    }

    public void JumpAnimation(bool jump)
    {
        animator.SetBool("Jump", jump);
    }
}
