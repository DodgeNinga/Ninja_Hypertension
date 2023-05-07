using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemCutScene : CutScene
{
    public override void StartCutScene()
    {

        CameraManager.instance.cvcam.Follow = transform;

        FAED.InvokeDelayReal(() =>
        {

            CameraManager.instance.Shake(2f, 2f, 1f, true);

            FAED.InvokeDelayReal(() =>
            {

                thisCutScene.EndCutScene();

            }, 1f);

        }, 1f);

    }

    public override void EndCutScene()
    {

        CameraManager.instance.SetTarget(true);

    }

}
