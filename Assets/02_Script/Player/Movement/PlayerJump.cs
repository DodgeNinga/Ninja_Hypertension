using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerBehaviorRoot
{

    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpAddValue;

    public bool jumpAble = true;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

    }

    private void JumpDown()
    {

        if (!jumpCol.isGround || !jumpAble) return;

        animator.SetJump();
        rigid.velocity += Vector2.up * jumpPower;
        StartCoroutine(AddJumpPowerCo());

    }

    private void JumpUp()
    {

        StopAllCoroutines();

    }

    public override void AddEvent()
    {

        actionSystem.OnJumpKeyDownEvent += JumpDown;
        actionSystem.OnJumpKeyUpEvent += JumpUp;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnJumpKeyDownEvent -= JumpDown;
        actionSystem.OnJumpKeyUpEvent -= JumpUp;

    }

    private IEnumerator AddJumpPowerCo()
    {

        float value = 0;

        while(value >= jumpAddValue) 
        {

            value += Time.deltaTime * jumpAddValue;

            rigid.velocity += Vector2.up * Time.deltaTime * jumpAddValue;

            yield return null;
        
        }

    }

}
