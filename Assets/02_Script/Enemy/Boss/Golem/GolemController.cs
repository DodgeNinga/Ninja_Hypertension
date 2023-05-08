using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemController : AIController
{

    private HitSencer sencer;
    private SpriteRenderer spriteRenderer;

    protected override void Awake()
    {

        base.Awake();

        sencer = GetComponent<HitSencer>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    protected override void Update()
    {

        base.Update();
        sencer.swap = spriteRenderer.flipX;

    }

}
