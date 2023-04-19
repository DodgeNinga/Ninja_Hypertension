using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : PlayerBehaviorRoot
{

    public bool useFlip = true;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

    }

    private void Flip(float value)
    {

        if (!useFlip) return;

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
