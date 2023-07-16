using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperRoarTrans : RangeTransition
{

    private ReaperRoarState state;

    private void Awake()
    {
        
        state = FindObjectOfType<ReaperRoarState>();

    }

    public override bool MakeTransition()
    {

        return base.MakeTransition() && !state.isCoolDown;

    }

}
