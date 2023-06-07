using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPound : PlayerBehaviorRoot
{

    [SerializeField] private PlayerBehaviorRoot[] removeEventScript;

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
        animator.fallDownAble = false;

        playerControllValue.isAnySkillAttack = true;
        isPounding = true;

        foreach(var item in removeEventScript) 
        {

            item.RemoveEvent();
        
        }

        StartCoroutine(PoundEndChackCo());

    }

    private IEnumerator PoundEndChackCo()
    {

        yield return new WaitUntil(() => jumpCol.isGround);

        animator.SetPoundEndTrigger();
        isPounding = false;
        playerControllValue.isAnySkillAttack = false;

        yield return new WaitForSeconds(0.2f);

        playerHitSencer.ChackHit("Pound");
        animator.fallDownAble = true;

        foreach (var item in removeEventScript)
        {

            item.AddEvent();

        }

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
