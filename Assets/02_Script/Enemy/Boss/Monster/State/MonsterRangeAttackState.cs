using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRangeAttackState : AIState
{

    private MonsterAnimator animator;

    public bool isCoolDown {  get; private set; }

    protected override void Awake()
    {

        base.Awake();

        animator = controller.GetComponent<MonsterAnimator>();

    }

    public override void EnterState()
    {

        animator.SetSpellTrigger();
        StartCoroutine(SpellCoolDownCo());
        
    }

    public override void ExitState()
    {



    }

    public override void UpdateState()
    {



    }

    private IEnumerator SpellCoolDownCo()
    {

        isCoolDown = true;
        yield return new WaitForSeconds(7f);
        isCoolDown = false;

    }

}
