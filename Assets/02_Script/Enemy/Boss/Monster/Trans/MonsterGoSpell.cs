using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGoSpell : RangeTransition
{

    private MonsterRangeAttackState state;

    private void Awake()
    {
        
        state = FindObjectOfType<MonsterRangeAttackState>();

    }

    public override bool MakeTransition()
    {

        return base.MakeTransition() && !state.isCoolDown;

    }

}
