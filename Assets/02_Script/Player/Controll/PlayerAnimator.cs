using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private readonly int MoveVelXHash = Animator.StringToHash("MoveVelX");
    private readonly int MoveVelYHash = Animator.StringToHash("MoveVelY");
    private readonly int JumpHash = Animator.StringToHash("Jump");
    private readonly int LandingHash = Animator.StringToHash("Landing");
    private readonly int LandingTriggerHash = Animator.StringToHash("LandingTrigger");

    private Animator animator;
    private Rigidbody2D rigid;

    private void Awake()
    {
        
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {

        SetMoveVelHash();

    }

    private void SetMoveVelHash()
    {

        animator.SetFloat(MoveVelXHash, Mathf.Abs(rigid.velocity.x));
        animator.SetFloat(MoveVelYHash, rigid.velocity.y);

    }

    public void SetJump()
    {

        animator.SetTrigger(JumpHash);

    }

}
