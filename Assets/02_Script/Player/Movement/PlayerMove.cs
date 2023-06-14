using System.Collections;
using System.Collections.Generic;
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

    private void Run()
    {

        if (playerControllValue.isAnySkillAttack) return;

        currentSpeed = currentSpeed * 1.5f;
        animator.SetIsRun(1);

    }

    private void EndRun()
    {

        currentSpeed = moveSpeed;
        animator.SetIsRun(0);

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

        if(value == -1)
        {

            currentSpeed = moveSpeed;

        }
        else
        {

            currentSpeed = value;

        }

    }

    public void Stop()
    {

        rigid.velocity = new Vector2(0, rigid.velocity.y);

    }

    public override void AddEvent()
    {

        actionSystem.OnHorizontalEvent += Move;
        actionSystem.OnRunKeyPressEvent += Run;
        actionSystem.OnRunKeyUpEvent += EndRun;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnHorizontalEvent -= Move;
        actionSystem.OnRunKeyPressEvent -= Run;
        actionSystem.OnRunKeyUpEvent -= EndRun;

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
