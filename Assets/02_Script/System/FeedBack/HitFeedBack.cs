using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeedBack : FeedBack
{

    [SerializeField] private float eftPlayTime;
    [SerializeField] private string eftPoolKey;

    private GameObject obj;

    public override void CreateFeedBack()
    {

        obj = FAED.Pop(eftPoolKey, transform.position, Quaternion.identity);

        Destroy(obj, eftPlayTime);

    }

    public override void EndFeedBack()
    {



    }

}
