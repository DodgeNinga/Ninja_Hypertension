using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperRoarState : AIState
{
    [SerializeField] private AudioSource s;
    private ReaperAnimator reaperAnimator;
    private ReaperHP reaperHP;

    public bool isCoolDown { get; private set; }

    protected override void Awake()
    {

        base.Awake();

        reaperAnimator = controller.GetComponent<ReaperAnimator>();
        reaperHP = controller.GetComponent<ReaperHP>();

    }

    public override void EnterState()
    {

        reaperAnimator.SetRoarTrigger();
        s.Play();
        reaperHP.HealingHP(100);
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
        yield return new WaitForSeconds(30f);
        isCoolDown = false;

    }

}
