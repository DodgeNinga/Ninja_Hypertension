using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemMeleeAttackState : AIState
{

    [SerializeField] private GameObject root;
    [SerializeField] private float coolDownTime;

    private GolemAnimator animator;
    public bool isCoolDown { get; private set; }

    protected override void Awake()
    {

        base.Awake();

        animator = root.GetComponent<GolemAnimator>();

    }

    public override void EnterState()
    {

        if (isCoolDown) return;

        //animator

    }

    public override void ExitState()
    {



    }

    public override void UpdateState()
    {



    }

}
