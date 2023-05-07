using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GolemAttackState : AIState
{

    [SerializeField] private float coolTimeMin, coolTimeMax;
    [SerializeField] private float atkCoolDownMin, atkCoolDownMax;

    private GolemAnimator animator;

    public bool isCoolDown { get; private set; }

    protected override void Awake()
    {

        base.Awake();

        animator = controller.GetComponent<GolemAnimator>();

    }

    public override void EnterState()
    {

        if (isCoolDown) return;

        isCoolDown = true;
        animator.SetIsAttack(true);
        StartCoroutine(SkillSelectCo());       

    }

    public override void ExitState()
    {

        animator.SetIsAttack(false);

    }

    public override void UpdateState()
    {
    }

    private IEnumerator SkillSelectCo()
    {

        yield return new WaitForSecondsRealtime(Random.Range(coolTimeMin, coolTimeMax));

        int randomIDX = Random.Range(0, 2);

        animator.SetAttackSelectInt(randomIDX);
        animator.SetAttackTrigger();

        FAED.InvokeDelayReal(() => isCoolDown = false, 
            Random.Range(atkCoolDownMin, atkCoolDownMax));

    }

}
