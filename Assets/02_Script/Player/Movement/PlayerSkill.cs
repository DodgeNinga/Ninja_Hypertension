using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : PlayerBehaviorRoot
{

    private readonly int OutLineValueHash = Shader.PropertyToID("_OuterOutlineFade");
    private readonly int OutLineColorHash = Shader.PropertyToID("_OuterOutlineColor");

    [SerializeField] private float lvUpTime = 1f;
    [SerializeField] private float holdMoveSpeed;

    private MaterialPropertyBlock propertyBlock;
    private PlayerMove playerMove;
    private int currentLV = 1;

    public bool skillAble = true;

    protected override void Awake()
    {

        base.Awake();
        propertyBlock = new MaterialPropertyBlock();
        playerMove = GetComponent<PlayerMove>();
        spriteRenderer.GetPropertyBlock(propertyBlock);
        
        AddEvent();

    }

    private void PressEvent()
    {

        if (!skillAble) return;

        spriteRenderer.material.SetFloat(OutLineValueHash, 1);
        playerMove.SetMoveSpeed(holdMoveSpeed);

        animator.SetSkillHoldHash(true);

        StartCoroutine(LvUpCo());

    }

    private void UpEvent()
    {

        if (!skillAble) return;

        spriteRenderer.material.SetFloat(OutLineValueHash, 0);
        currentLV = 0;

        animator.SetSkillHoldHash(false);
        playerMove.SetMoveSpeed(-1);

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
