using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperHoldTrans : RangeTransition
{

    private ReaperHoldAttackState state;

    private void Awake()
    {
        
        state = FindObjectOfType<ReaperHoldAttackState>();

    }

    public override bool MakeTransition()
    {

        return base.MakeTransition() && !state.isCoolDown;

    }

}
