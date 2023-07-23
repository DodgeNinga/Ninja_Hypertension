using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackState : AIState
{

    [SerializeField] private AudioSource s;
    private MonsterAnimator animator;

    public bool isCoolDown {  get; private set; }

    protected override void Awake()
    {

        base.Awake();

        animator = controller.GetComponent<MonsterAnimator>();

    }

    public override void EnterState()
    {

        animator.SetAttackTrigger();
        s.Play();
        StartCoroutine(AttackDelCo());

    }

    public override void ExitState()
    {



    }

    public override void UpdateState()
    {



    }

    private IEnumerator AttackDelCo()
    {

        isCoolDown = true;
        yield return new WaitForSeconds(3f);
        isCoolDown = false;

    }

}
