using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GolemAttackState : AIState
{

    [SerializeField] private float coolTimeMin, coolTimeMax;

    public override void EnterState()
    {

        StartCoroutine(SkillSelectCo());       

    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
    }

    private IEnumerator SkillSelectCo()
    {

        yield return new WaitForSecondsRealtime(Random.Range(coolTimeMin, coolTimeMax));

        int randomIDX = Random.Range(0, 8);

    }

}
