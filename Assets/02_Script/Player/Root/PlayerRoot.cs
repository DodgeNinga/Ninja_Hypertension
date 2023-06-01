using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoot : MonoBehaviour
{

    protected PlayerAnimator animator;
    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rigid;
    protected PlayerActionSystem actionSystem;
    protected PlayerControllValue playerControllValue;
    protected JumpCol jumpCol;

    protected virtual void Awake()
    {

        animator = GetComponent<PlayerAnimator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        playerControllValue = GetComponent<PlayerControllValue>();

        jumpCol = GetComponentInChildren<JumpCol>();

        actionSystem = transform.Find("Input").GetComponent<PlayerActionSystem>();

    }

}
