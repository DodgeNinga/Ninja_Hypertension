using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPound : PlayerBehaviorRoot
{

    private HitSencer playerHitSencer;
    private bool isPounding = false;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

        playerHitSencer = GetComponent<HitSencer>();

    }

    private void Pounding()
    {

        if (jumpCol.isGround || playerControllValue.isAnySkillAttack || isPounding) return;

        rigid.velocity -= new Vector2(0, 7);
        animator.SetPoundTrigger();
        playerControllValue.isAnySkillAttack = true;
        isPounding = true;

        StartCoroutine(PoundEndChackCo());

    }

    private IEnumerator PoundEndChackCo()
    {

        yield return new WaitUntil(() => jumpCol.isGround);

        animator.SetPoundEndTrigger();
        isPounding = false;
        playerControllValue.isAnySkillAttack = false;
        playerHitSencer.ChackHit("Pound");

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
