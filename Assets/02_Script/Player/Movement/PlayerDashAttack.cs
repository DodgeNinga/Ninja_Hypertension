using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashAttack : PlayerBehaviorRoot
{

    private PlayerMove playerMove;

    protected override void Awake()
    {
        
        base.Awake();

        AddEvent();

        playerMove = GetComponent<PlayerMove>();

    }

    private void DashAttack()
    {

        if (!jumpCol.isGround ||
            playerControllValue.isHoldAttack ||
            playerControllValue.isAnySkillAttack) return;

        playerControllValue.isAnySkillAttack = true;
        playerMove.SetMoveSpeed(1);
        

    }

    private void EndHold()
    {



    }

    public override void AddEvent()
    {

        actionSystem.OnDashAttackKeyPressEvent += DashAttack;
        actionSystem.OnHoldSkillKeyUpEvent += EndHold;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnDashAttackKeyPressEvent -= DashAttack;
        actionSystem.OnHoldSkillKeyUpEvent -= EndHold;

    }

}
