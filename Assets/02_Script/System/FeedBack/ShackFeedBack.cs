using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShackFeedBack : FeedBack
{

    [SerializeField] private float shakePower = 1f, shakeCount = 1f, duration = 0.3f;

    public override void CreateFeedBack()
    {
        
        if(CameraManager.instance != null) 
        {

            CameraManager.instance.Shake(shakePower, shakeCount, duration, true);

        }

    }

    public override void EndFeedBack()
    {
        
    }
}
