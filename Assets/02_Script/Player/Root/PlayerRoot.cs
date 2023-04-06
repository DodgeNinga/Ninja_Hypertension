using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoot : MonoBehaviour
{

    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rigid;
    protected PlayerActionSystem actionSystem;

    protected virtual void Awake()
    {

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();

        actionSystem = transform.Find("Input").GetComponent<PlayerActionSystem>();

    }

}
