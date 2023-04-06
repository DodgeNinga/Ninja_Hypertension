using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerBehaviorRoot
{

    [SerializeField] private float moveSpeed;

    public override void AddEvent()
    {

        actionSystem.OnHorizontalEvnet += Move;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnHorizontalEvnet -= Move;

    }

    private void Move(float inputX)
    {

        rigid.velocity = new Vector2(inputX * moveSpeed, rigid.velocity.y);

    }

}
