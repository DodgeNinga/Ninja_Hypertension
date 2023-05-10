using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemCutScene : CutScene
{

    [SerializeField] private AudioSource playSource;

    public override void StartCutScene()
    {

        CameraManager.instance.cvcam.Follow = transform;

        FAED.InvokeDelayReal(() =>
        {

            CameraManager.instance.Shake(5f, 5f, 2.5f, true);
            playSource.Play();

            FAED.InvokeDelayReal(() =>
            {

                thisCutScene.EndCutScene();

            }, 2.5f);

        }, 1f);

    }

    public override void EndCutScene()
    {

        CameraManager.instance.SetTarget(true);

    }

}
