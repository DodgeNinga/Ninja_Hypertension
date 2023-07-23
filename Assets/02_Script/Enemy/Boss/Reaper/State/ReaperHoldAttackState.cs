using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperHoldAttackState : AIState
{

    [SerializeField] private AudioSource s;

    private List<LineSkill> lineEffects = new List<LineSkill>();
    private Transform target;
    private ReaperAnimator reaperAnimator;

    public bool isCoolDown { get; private set; }

    protected override void Awake()
    {

        base.Awake();

        target = GameObject.Find("Player").transform;
        reaperAnimator = controller.GetComponent<ReaperAnimator>();

    }

    public override void EnterState()
    {

        reaperAnimator.SetHoldAttackTrigger();

        FAED.InvokeDelay(() =>
        {

            for (int i = 0; i < 10; i++)
            {

                var summonVec = target.position + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));

                var obj = FAED.Pop("SkillLine", summonVec, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360f)))).GetComponent<LineSkill>();

                lineEffects.Add(obj);
                s.Play();

            }

        }, 0.2f);

        StartCoroutine(HoldAttaclCoolDownCo());

    }

    public override void ExitState()
    {



    }

    public override void UpdateState()
    {



    }

    public void AttackLine()
    {

        foreach(var item in lineEffects)
        {

            item.SetSkill();

        }

        lineEffects.Clear();

    }

    private IEnumerator HoldAttaclCoolDownCo()
    {

        isCoolDown = true;
        yield return new WaitForSeconds(15f);
        isCoolDown = false;

    }

}
