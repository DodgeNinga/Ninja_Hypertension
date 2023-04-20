using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerBehaviorRoot
{

    [SerializeField] private float jumpPower;

    [HideInInspector] public bool jumpAble = true;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

    }

    private void Jump()
    {

        if (!jumpCol.isGround || !jumpAble) return;

        animator.SetJump();
        rigid.velocity += Vector2.up * jumpPower;

    }

    public override void AddEvent()
    {

        actionSystem.OnJumpKeyEvent += Jump;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnJumpKeyEvent -= Jump;

    }
}
