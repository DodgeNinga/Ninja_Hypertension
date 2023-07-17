using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperHoldAttackState : AIState
{

    private List<LineSkill> lineEffects = new List<LineSkill>();
    private Transform target;

    protected override void Awake()
    {

        base.Awake();

        target = GameObject.Find("Player").transform;

    }

    public override void EnterState()
    {

        for(int i = 0; i < 10; i++) 
        {

            var summonVec = target.position + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));

            var obj = FAED.Pop("SkillLine", summonVec, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360f)))).GetComponent<LineSkill>();

            lineEffects.Add(obj);

        }

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

}
