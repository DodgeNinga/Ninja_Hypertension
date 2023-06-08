using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashAttack : PlayerBehaviorRoot
{

    [SerializeField] private PlayerBehaviorRoot[] removeEvts;

    private PlayerMove playerMove;
    private bool isDashHolding = false;

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
        isDashHolding = true;
        playerMove.SetMoveSpeed(1);
        animator.SetDashAttackTrigger();


    }

    private void EndHold()
    {

        if(playerControllValue.isHoldAttack || !isDashHolding) return;

        isDashHolding = false;
        animator.SetDashAttackHoldingEndTrigger();
        playerMove.SetMoveSpeed(-1);

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
