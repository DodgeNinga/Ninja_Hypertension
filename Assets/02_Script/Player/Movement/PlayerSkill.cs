using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : PlayerBehaviorRoot
{

    private readonly int OutLineValueHash = Shader.PropertyToID("_OuterOutlineFade");
    private readonly int OutLineColorHash = Shader.PropertyToID("_OuterOutlineColor");

    [SerializeField] private float lvUpTime = 1f;

    private MaterialPropertyBlock propertyBlock;
    private int currentLV = 1;

    public bool skillAble = true;

    protected override void Awake()
    {

        base.Awake();
        spriteRenderer.GetPropertyBlock(propertyBlock);
        AddEvent();

    }

    private void PressEvent()
    {

        if (!skillAble) return;

        propertyBlock.SetFloat(OutLineValueHash, 1);
        spriteRenderer.SetPropertyBlock(propertyBlock);

        StartCoroutine(LvUpCo());

    }

    private void UpEvent()
    {

        if (!skillAble) return;

        propertyBlock.SetFloat(OutLineValueHash, 0);
        spriteRenderer.SetPropertyBlock(propertyBlock);
        StopAllCoroutines();

    }

    public override void AddEvent()
    {

        actionSystem.OnHoldSkillPressEvnet += PressEvent;
        actionSystem.OnHoldSkillKeyUpEvent += UpEvent;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnHoldSkillPressEvnet -= PressEvent;
        actionSystem.OnHoldSkillKeyUpEvent -= UpEvent;

    }

    private IEnumerator LvUpCo()
    {

        while(currentLV != 3)
        {

            propertyBlock.SetColor(OutLineColorHash, currentLV switch
            {

                1 => Color.white,
                2 => Color.cyan,
                3 => Color.red,
                _ => Color.black

            });
            spriteRenderer.SetPropertyBlock(propertyBlock);

            yield return new WaitForSeconds(lvUpTime);
            currentLV++;


        }

    }

}
