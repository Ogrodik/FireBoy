using UnityEngine;

[RequireComponent(typeof(MoveController))]
[RequireComponent(typeof(JumpController))]
[RequireComponent(typeof(AnimatorController))]
[RequireComponent(typeof(AttackController))]
[RequireComponent(typeof(SpriteController))]
public class InputManager : MonoBehaviour
{
    private MoveController move;
    private JumpController jump;
    private AnimatorController animator;
    private AttackController attack;
    private SpriteController sprite;

    private void Awake()
    {
        move = GetComponent<MoveController>();
        jump = GetComponent<JumpController>();
        animator = GetComponent<AnimatorController>();
        attack = GetComponent<AttackController>();
        sprite = GetComponent<SpriteController>();
    }

    private void Update()
    {
        JumpCheck();
        AttackCheck();
    }

    private void FixedUpdate()
    {
        MoveCheck();
    }

    private void MoveCheck()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            move.Move();
            sprite.RotateSprite(Input.GetAxis("Horizontal"));
            animator.MoveAnimation();
        }
    }

    private void JumpCheck()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump.Jump();
            animator.JumpAnimation(true);
        }
    }

    private void AttackCheck()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            attack.Attack();
        }        
    }
}
