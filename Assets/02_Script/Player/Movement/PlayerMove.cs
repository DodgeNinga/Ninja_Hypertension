using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlayerMove : PlayerBehaviorRoot
{

    [SerializeField] private float moveSpeed;

    private bool moveAble = true;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();
        

    }

    private void Move(float inputX)
    {

        if (!moveAble) return;

        rigid.velocity = new Vector2(inputX * moveSpeed, rigid.velocity.y);

    }

    public void KnockBack(Vector2 vel)
    {

        StartCoroutine(KnockBackCo(vel));

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
