using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlayerMove : PlayerBehaviorRoot
{

    [SerializeField] private float moveSpeed;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();
        

    }

    private void Move(float inputX)
    {

        rigid.velocity = new Vector2(inputX * moveSpeed, rigid.velocity.y);

    }

    public override void AddEvent()
    {

        actionSystem.OnHorizontalEvent += Move;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnHorizontalEvent -= Move;

    }


}
