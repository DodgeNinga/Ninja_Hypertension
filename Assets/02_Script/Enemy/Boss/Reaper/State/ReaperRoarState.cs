using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperRoarState : AIState
{

    private ReaperAnimator reaperAnimator;

    protected override void Awake()
    {

        base.Awake();

        reaperAnimator = transform.parent.parent.GetComponent<ReaperAnimator>();

    }

    public override void EnterState()
    {

        reaperAnimator.SetRoarTrigger();

    }

    public override void ExitState()
    {



    }

    public override void UpdateState()
    {



    }

}
