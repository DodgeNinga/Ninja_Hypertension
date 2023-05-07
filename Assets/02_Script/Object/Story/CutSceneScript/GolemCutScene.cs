using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemCutScene : CutScene
{

    private CameraTakeManager camTakeManager;

    private void Awake()
    {
        
        camTakeManager = FindObjectOfType<CameraTakeManager>();

    }

    public override void StartCutScene()
    {

        camTakeManager.StartTake("Golem");
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

        //

    }

}
