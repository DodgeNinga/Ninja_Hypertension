using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerSkill : PlayerBehaviorRoot
{

    private readonly int OutLineValueHash = Shader.PropertyToID("_OuterOutlineFade");
    private readonly int OutLineColorHash = Shader.PropertyToID("_OuterOutlineColor");

    [SerializeField] private float lvUpTime = 1f;
    [SerializeField] private float holdMoveSpeed;

    private MaterialPropertyBlock propertyBlock;
    private PlayerMove playerMove;
    private PlayerFlip flip;
    private int currentLV = 1;

    public bool skillAble = true;

    protected override void Awake()
    {

        base.Awake();
        propertyBlock = new MaterialPropertyBlock();
        playerMove = GetComponent<PlayerMove>();
        flip = GetComponent<PlayerFlip>();
        spriteRenderer.GetPropertyBlock(propertyBlock);
        
        AddEvent();

    }

    private void PressEvent()
    {

        if (!skillAble) return;

        spriteRenderer.material.SetFloat(OutLineValueHash, 1);
        playerMove.SetMoveSpeed(holdMoveSpeed);

        animator.SetSkillHoldHash(true);
        animator.SetSkillHoldTriggerHash();

        StartCoroutine(LvUpCo());

    }

    private void UpEvent()
    {

        if (!skillAble) return;

        spriteRenderer.material.SetFloat(OutLineValueHash, 0);
        currentLV = 1;
        flip.flipAble = false;

        animator.SetSkillHoldHash(false);


        StopAllCoroutines();

    }

    public void HoldEventEnd()
    {

        flip.flipAble = true;
        playerMove.SetMoveSpeed(-1);

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

        while(currentLV <= 3)
        {

            spriteRenderer.material.SetColor(OutLineColorHash, currentLV switch
            {

                1 => Color.white,
                2 => Color.cyan,
                3 => Color.red,
                _ => Color.black

            });

            yield return new WaitForSeconds(lvUpTime);
            currentLV++;


        }

    }

}
