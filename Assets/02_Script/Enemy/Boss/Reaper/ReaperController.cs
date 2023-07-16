using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperController : AIController
{

    private HitSencer hitSencer;
    private SpriteRenderer spriteRenderer;

    protected override void Awake()
    {

        base.Awake();

        hitSencer = GetComponent<HitSencer>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    protected override void Update()
    {

        base.Update();

        hitSencer.swap = spriteRenderer.flipX;

    }

}
