using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerBehaviorRoot
{

    [SerializeField] private float comboAbleTime = 0.2f;

    private int comboCnt;
    private bool attackAble;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

    }
        
    private void Attack()
    {

        if (!attackAble) return;

        comboCnt++;
        attackAble = false;

    }

    public void SetAttackAble(float value)
    {

        attackAble = value > 0 ? true : false;

    }

    public override void AddEvent()
    {

        actionSystem.OnSkillKeyPressEvent += Attack;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnSkillKeyPressEvent -= Attack;

    }

}
