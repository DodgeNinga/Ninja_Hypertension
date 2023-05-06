using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemIdleState : AIState
{

    private GolemAnimator animator;

    protected override void Awake()
    {

        base.Awake();

        animator = controller.GetComponent<GolemAnimator>();

    }

    public override void EnterState()
    {

        animator.SetIsMove(false);

    }
    public override void UpdateState()
    {



    }

    public override void ExitState()
    {



    }

}
