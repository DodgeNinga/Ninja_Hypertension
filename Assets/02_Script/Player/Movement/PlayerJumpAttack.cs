using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAttack : PlayerBehaviorRoot
{

    private PlayerJump playerJump;

    protected override void Awake()
    {

        base.Awake();
        
        playerJump = GetComponent<PlayerJump>();

        AddEvent();

    }

    private void JumpAttack()
    {

        if (!jumpCol.isGround || 
            !playerJump.jumpAble || 
            playerControllValue.isHoldAttack ||
            rigid.velocity.y <= 0) return;

        animator.SetJumpAttackTrigger();
        playerControllValue.isJumpAttack = true;

    }

    public void SetEndJumpAttack()
    {

        playerControllValue.isJumpAttack = false;

    }

    public override void AddEvent()
    {

        actionSystem.OnJumpAttackKeyPressEvent += JumpAttack;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnJumpAttackKeyPressEvent -= JumpAttack;

    }

}
