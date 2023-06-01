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

    private void JumpAttact()
    {

        if (!jumpCol.isGround || !playerJump.jumpAble) return;

        animator.SetJumpAttackTrigger();

    }

    public override void AddEvent()
    {

        actionSystem.OnJumpAttackKeyPressEvent += JumpAttact;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnJumpAttackKeyPressEvent -= JumpAttact;

    }

}
