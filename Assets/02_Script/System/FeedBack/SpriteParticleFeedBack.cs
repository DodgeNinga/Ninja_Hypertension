using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteParticleFeedBack : FeedBack
{

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public override void CreateFeedBack()
    {

        var particle = FAED.Pop("SpriteParticle", transform.position, Quaternion.identity)
            .GetComponent<SpriteParticle>();

        particle.MakeParticle(spriteRenderer.sprite);

    }

    public override void EndFeedBack()
    {        
    }

}