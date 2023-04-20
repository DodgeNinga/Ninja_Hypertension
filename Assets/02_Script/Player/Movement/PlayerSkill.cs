using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : PlayerBehaviorRoot
{

    private readonly int OutLineValueHash = Shader.PropertyToID("_OuterOutlineFade");

    private MaterialPropertyBlock propertyBlock;

    protected override void Awake()
    {

        base.Awake();
        spriteRenderer.GetPropertyBlock(propertyBlock);

    }

    public override void AddEvent()
    {
        
    }

    public override void RemoveEvent()
    {
        
    }
}
