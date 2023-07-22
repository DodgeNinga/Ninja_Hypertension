using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGoAttack : RangeTransition
{

    private MonsterAttackState state;

    private void Awake()
    {
        
        state = FindObjectOfType<MonsterAttackState>();

    }

    public override bool MakeTransition()
    {

        return base.MakeTransition() && !state.isCoolDown;

    }

}
