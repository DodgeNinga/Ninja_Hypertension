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

        if (!jumpCol.isGround || !playerJump.jumpAble) return;

        animator.SetJumpAttackTrigger();
        playerControllValue.isJumpAttack = true;

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
