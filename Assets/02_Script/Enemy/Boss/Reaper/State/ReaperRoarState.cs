using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperRoarState : AIState
{

    private ReaperAnimator reaperAnimator;

    public bool isCoolDown { get; private set; }

    protected override void Awake()
    {

        base.Awake();

        reaperAnimator = transform.parent.parent.GetComponent<ReaperAnimator>();

    }

    public override void EnterState()
    {

        reaperAnimator.SetRoarTrigger();
        StartCoroutine(RoarCoolDownCo());

    }

    public override void ExitState()
    {



    }

    public override void UpdateState()
    {



    }

    private IEnumerator RoarCoolDownCo()
    {

        isCoolDown = true;
        yield return new WaitForSeconds(2f);
        isCoolDown = false;

    }

}
