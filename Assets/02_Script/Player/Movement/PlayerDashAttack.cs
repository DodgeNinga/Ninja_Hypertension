using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashAttack : PlayerBehaviorRoot
{

    [SerializeField] private PlayerBehaviorRoot[] removeEvts;
    [SerializeField] private float dashPower;
    [SerializeField] private float dashTime;
    [SerializeField] private float skillCoolTime;

    private PlayerMove playerMove;
    private ParticlePlayer particlePlayer;
    private PlayerInvincibility invincibility;
    private PlayerSoundManager soundManager;
    private bool isDashHolding = false;
    private bool isSkillCoolDown = false;

    protected override void Awake()
    {
        
        base.Awake();

        AddEvent();

        playerMove = GetComponent<PlayerMove>();
        particlePlayer = transform.Find("ParticlePlayer").Find("DashParticle").GetComponent<ParticlePlayer>();
        soundManager = GetComponent<PlayerSoundManager>();

    }

    private void DashAttack()
    {

        if (!jumpCol.isGround ||
            playerControllValue.isHoldAttack ||
            playerControllValue.isAnySkillAttack ||
            isSkillCoolDown) return;

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
        
        StartCoroutine(StartDashCo());
        StartCoroutine(DashEndCo());


    }

    private void DashEnd()
    {

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

    private IEnumerator StartDashCo()
    {

        yield return null;

        soundManager.PlayDashSound();
        float curDashPower = spriteRenderer.flipX ? -dashPower : dashPower;
        particlePlayer.StartPlay(transform.position, Quaternion.identity, spriteRenderer.flipX switch
        {

            true => -1,
            false => 1

        }, transform);

        rigid.velocity = new Vector2(curDashPower, 0);

    }

    private IEnumerator DashEndCo()
    {

        yield return new WaitForSeconds(dashTime);

        DashEnd();

        yield return new WaitForSeconds(skillCoolTime);

    }

}
