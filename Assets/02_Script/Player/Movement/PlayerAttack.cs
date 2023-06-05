using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerBehaviorRoot
{

    [SerializeField] private float comboAbleTime = 0.2f;
    [SerializeField] private float attackDelayTime = 1;

    private PlayerMove playerMove;
    private PlayerJump playerJump;
    private PlayerFlip playerFlip;
    private PlayerDash playerDash;
    private int comboCnt;
    private bool attackAble = true;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

        playerMove = GetComponent<PlayerMove>();
        playerJump = GetComponent<PlayerJump>();
        playerFlip = GetComponent<PlayerFlip>();
        playerDash = GetComponent<PlayerDash>();

    }
        
    private void Attack()
    {

        if (!attackAble || playerControllValue.isAnySkillAttack) return;
        attackAble = false;
        playerJump.jumpAble = false;
        playerFlip.flipAble = false;
        playerDash.RemoveEvent();

        StopAllCoroutines();
        playerMove.SetMoveAble(0);
        comboCnt++;

        animator.SetAttackTrigger();

        animator.SetComboCount(comboCnt);

    }

    public void SetAttackAble(float value)
    {

        attackAble = value > 0 ? true : false;

    }

    public void EndAttackAnime()
    {

        playerFlip.flipAble = true;
        playerJump.jumpAble = true;
        attackAble = true;
        StartCoroutine(ComboAbleTimeCo());

    }

    public void EndAttack()
    {

        FAED.InvokeDelay(() => 
        {

            animator.SetEndAttack();
            playerMove.SetMoveAble(1);
            playerJump.jumpAble = true;
            playerFlip.flipAble = true;

        }, 0.2f);
        attackAble = false;
        StartCoroutine(AttackDelayCo());

    }

    public void EndAllEvent() => playerDash.AddEvent();

    public void ResetAnimeValue()
    {

        comboCnt = 0;
        playerMove.SetMoveAble(1);
        playerFlip.flipAble = true;
        playerJump.jumpAble = true;
        attackAble = true;
        StopAllCoroutines();

    }

    public override void AddEvent()
    {

        actionSystem.OnSkillKeyPressEvent += Attack;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnSkillKeyPressEvent -= Attack;

    }

    private IEnumerator ComboAbleTimeCo()
    {
        
        yield return new WaitForSeconds(comboAbleTime);
        EndAttack();

    }

    private IEnumerator AttackDelayCo()
    {

        yield return new WaitForSeconds(attackDelayTime);
        comboCnt = 0;
        attackAble = true;

    }

}