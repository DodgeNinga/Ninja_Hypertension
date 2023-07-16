using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperAttackTrans : RangeTransition
{

    private ReaperAttackState state;

    private void Awake()
    {
        
        state = FindObjectOfType<ReaperAttackState>();

    }

    public override bool MakeTransition()
    {

        return base.MakeTransition() && !state.isCoolDown;

    }

}
