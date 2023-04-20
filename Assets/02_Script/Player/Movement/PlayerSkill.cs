using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : PlayerBehaviorRoot
{

    private readonly int OutLineValueHash = Shader.PropertyToID("_OuterOutlineFade");

    [SerializeField] private float lvUpTime = 1f;

    private MaterialPropertyBlock propertyBlock;
    private bool addValue;
    private int currentLV = 1;

    public bool skillAble = true;

    protected override void Awake()
    {

        base.Awake();
        spriteRenderer.GetPropertyBlock(propertyBlock);
        AddEvent();

    }

    private void Update()
    {
        
        

    }

    private void PressEvent()
    {



    }

    private void UpEvent()
    {



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

            yield return new WaitForSeconds(lvUpTime);
            currentLV++;

        }

    }

}
