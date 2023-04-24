using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStopFeedBack : FeedBack
{

    [SerializeField] private float stopTimeScale = 0.2f;
    [SerializeField] private float hitStopDuration = 0.2f;

    public override void CreateFeedBack()
    {
        
        Manager.TimeManagerIns.SetTimeScale(hitStopDuration, stopTimeScale);

    }

    public override void EndFeedBack()
    {
        
    }
}
