using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : PlayerBehaviorRoot
{

    private float rollingCoolDown = 1f;
    private bool rollingAble = true;

    protected override void Awake()
    {
        
        base.Awake();

        AddEvent();

    }

    private void Rolling()
    {

        if (jumpCol.isGround || playerControllValue.isAnySkillAttack || !rollingAble) return;

        animator.SetRollingTrigger();
        playerControllValue.isAnySkillAttack = true;
        StartCoroutine(RollingCoolDownCo());

    }

    public override void AddEvent()
    {

        actionSystem.OnRollingAttaclKeyPressEvent += Rolling;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnRollingAttaclKeyPressEvent -= Rolling;

    }

    private IEnumerator RollingCoolDownCo()
    {

        rollingAble = false;
        yield return new WaitForSeconds(rollingCoolDown);
        rollingAble = true;

    }

}
