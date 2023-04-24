using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : PlayerBehaviorRoot
{

    private HitSencer hitSencer;

    public bool useFlip = true;
    public bool flipAble = true;

    protected override void Awake()
    {

        base.Awake();

        hitSencer = GetComponent<HitSencer>();
        AddEvent();

    }

    private void Flip(float value)
    {

        if (!useFlip || !flipAble) return;

        spriteRenderer.flipX = value switch
        {
            
            1 => false,
            -1 => true,
            _ => spriteRenderer.flipX

        };

        hitSencer.swap = spriteRenderer.flipX;

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
