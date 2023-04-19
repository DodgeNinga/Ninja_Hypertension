using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private readonly int MoveVelXHash = Animator.StringToHash("MoveVelX");
    private readonly int MoveVelYHash = Animator.StringToHash("MoveVelY");
    private readonly int JumpHash = Animator.StringToHash("Jump");
    private readonly int LandingTriggerHash = Animator.StringToHash("LandingTrigger");

    private Animator animator;
    private Rigidbody2D rigid;
    private JumpCol jumpCol;
    private float fallDownTime;

    private void Awake()
    {
        
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpCol = GetComponentInChildren<JumpCol>();

    }

    private void Update()
    {

        SetMoveVelHash();
        FallDownChack();
        ChackLanding();

    }
    private void SetMoveVelHash()
    {

        animator.SetFloat(MoveVelXHash, Mathf.Abs(rigid.velocity.x));
        animator.SetFloat(MoveVelYHash, rigid.velocity.y);

    }
    private void FallDownChack()
    {

        if(rigid.velocity.y < 0) 
        {
            
            fallDownTime += Time.deltaTime;

        }
        else
        {

            fallDownTime = 0;

        }


    }
    private void ChackLanding()
    {

        if(fallDownTime > 1f && jumpCol.isGround == true)
        {

            fallDownTime = 0;
            animator.SetTrigger(LandingTriggerHash);

        }

    }
    public void SetJump()
    {

        animator.SetTrigger(JumpHash);

    }

}
