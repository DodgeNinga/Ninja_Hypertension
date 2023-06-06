using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPound : PlayerBehaviorRoot
{

    private bool isPounding = false;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

    }

    private void Pounding()
    {

        if (!jumpCol.isGround || playerControllValue.isAnySkillAttack || isPounding) return;

        rigid.velocity += new Vector2(0, -2);

    }

    public override void AddEvent()
    {

        actionSystem.OnPoundKeyPressEvent += Pounding;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnPoundKeyPressEvent -= Pounding;

    }
}
