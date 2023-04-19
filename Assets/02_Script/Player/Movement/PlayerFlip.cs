using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : PlayerBehaviorRoot
{

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

    }

    private void Flip(float value)
    {

        spriteRenderer.flipX = value switch
        {

            1 => false,
            -1 => true,
            _ => spriteRenderer.flipX

        };

    }

    public override void AddEvent()
    {

        actionSystem.OnHorizontalRawEvent += Flip;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnHorizontalRawEvent -= Flip;

    }

}
