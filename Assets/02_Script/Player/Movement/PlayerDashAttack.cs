using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashAttack : PlayerBehaviorRoot
{

    protected override void Awake()
    {
        
        base.Awake();

        AddEvent();

    }

    private void DashAttack()
    {



    }

    public override void AddEvent()
    {

        actionSystem.OnDashAttackKeyPressEvent += DashAttack;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnDashAttackKeyPressEvent -= DashAttack;

    }

}
