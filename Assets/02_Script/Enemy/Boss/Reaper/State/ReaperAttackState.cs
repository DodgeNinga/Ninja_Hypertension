using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperAttackState : AIState
{

    [SerializeField] private AudioSource s;
    private ReaperAnimator reaperAnimator;

    public bool isCoolDown { get; private set; }

    protected override void Awake()
    {

        base.Awake();

        reaperAnimator = transform.parent.parent.GetComponent<ReaperAnimator>();

    }

    public override void EnterState()
    {

        reaperAnimator.SetAttackTrigger();
        s.Play();
        StartCoroutine(AttackCoolDownCo());

    }

    public override void ExitState()
    {



    }

    public override void UpdateState()
    {



    }

    private IEnumerator AttackCoolDownCo()
    {

        isCoolDown = true;
        yield return new WaitForSeconds(3f);
        isCoolDown = false;

    }

}
