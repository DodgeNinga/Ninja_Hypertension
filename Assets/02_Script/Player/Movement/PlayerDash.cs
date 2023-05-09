using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : PlayerBehaviorRoot
{

    [SerializeField] private float dashPower;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCoolTime;
    [SerializeField] private List<PlayerBehaviorRoot> manageBehaviors = new List<PlayerBehaviorRoot>();

    private float originGravityScale;
    private AddGravity gravity;
    private ParticlePlayer particlePlayer;
    private PlayerInvincibility invincibility;
    private PlayerSoundManager soundManager;

    public bool dashAble { get; set; } = true;

    protected override void Awake()
    {

        base.Awake();

        gravity = GetComponent<AddGravity>();
        AddEvent();
        invincibility = GetComponent<PlayerInvincibility>();

        originGravityScale = rigid.gravityScale;

        particlePlayer = transform.Find("ParticlePlayer").Find("DashParticle").GetComponent<ParticlePlayer>();
        soundManager = GetComponent<PlayerSoundManager>();

    }

    private void Dash()
    {

        if (!dashAble) return;

        rigid.gravityScale = 0;
        gravity.onGravity = false;
        dashAble = false;

        foreach(var item in manageBehaviors) 
        {
        
            item.RemoveEvent();

        }

        invincibility.isInvincibility = true;
        StartCoroutine(StartDashCo());
        StartCoroutine(DashEndCo());

    }

    private void DashEnd()
    {

        invincibility.isInvincibility = false;
        gravity.onGravity = true;
        rigid.gravityScale = originGravityScale;
        animator.SetIsDash(false);

        FAED.InvokeDelayReal(() => particlePlayer.EndPlay(), 0.5f);  

        foreach (var item in manageBehaviors)
        {

            item.AddEvent();

        }

    }

    public override void AddEvent()
    {

        actionSystem.OnDashKeyPressEvent += Dash;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnDashKeyPressEvent -= Dash;

    }

    private IEnumerator StartDashCo()
    {

        yield return null;

        soundManager.PlayDashSound();
        float curDashPower = spriteRenderer.flipX ? -dashPower : dashPower;
        animator.SetDashTrigger();
        animator.SetIsDash(true);
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

        yield return new WaitForSeconds(dashCoolTime);

        dashAble = true;

    }

}
