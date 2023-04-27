using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeedBack : FeedBack
{

    [SerializeField] private float eftPlayTime;
    [SerializeField] private string[] eftPoolKey;

    public override void CreateFeedBack()
    {

        foreach(var item in eftPoolKey)
        {

            var obj = FAED.Pop(item, 
                transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)),
                Quaternion.identity);

            var ptc = obj.GetComponent<ParticleSystem>();
            ptc.Play();

            Destroy(obj, eftPlayTime);

        }

    }

    public override void EndFeedBack()
    {



    }

}
