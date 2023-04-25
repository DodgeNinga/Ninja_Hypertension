using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShackFeedBack : FeedBack
{

    [SerializeField] private float shakePower = 1f, shakeCount = 1f;

    public override void CreateFeedBack()
    {
        
        if(CameraManager.instance != null) 
        {

            CameraManager.instance.Shake(shakePower, shakeCount, 0.3f, true);

        }

    }

    public override void EndFeedBack()
    {
        
    }
}
