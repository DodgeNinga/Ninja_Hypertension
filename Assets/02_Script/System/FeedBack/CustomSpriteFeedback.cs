using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSpriteFeedback : FeedBack
{

    [SerializeField] private string customPoolName;

    public override void CreateFeedBack()
    {

        var obj = FAED.Pop(customPoolName, transform.position, Quaternion.identity).GetComponent<CustomSpriteParticle>();

        obj.PlayParticle();

    }

    public override void EndFeedBack()
    {



    }

}
