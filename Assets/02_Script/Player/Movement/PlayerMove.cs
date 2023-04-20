using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlayerMove : PlayerBehaviorRoot
{

    [SerializeField] private float moveSpeed;

    private float currentSpeed;

    private bool moveAble = true;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();
        currentSpeed = moveSpeed;


    }

    private void Move(float inputX)
    {

        if (!moveAble) return;

        rigid.velocity = new Vector2(inputX * currentSpeed, rigid.velocity.y);

    }

    public void KnockBack(Vector2 vel)
    {

        StartCoroutine(KnockBackCo(vel));

    }

    public void SetMoveAble(float value)
    {

        moveAble = value switch
        {

            0 => false,
            1 => true,
            _ => false,

        };
    
    }

    public void SetMoveSpeed(float value)
    {

        if(value <= -1)
        {

            currentSpeed = moveSpeed;

        }

        currentSpeed = value;

    }

    public override void AddEvent()
    {

        actionSystem.OnHorizontalEvent += Move;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnHorizontalEvent -= Move;

    }

    private IEnumerator KnockBackCo(Vector2 vel)
    {

        moveAble = false;
        rigid.velocity = vel;
        yield return new WaitUntil(() =>
        {

            return rigid.velocity == Vector2.zero;

        });

        moveAble = true;
    }

}
