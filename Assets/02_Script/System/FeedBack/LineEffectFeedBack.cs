using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEffectFeedBack : FeedBack
{
    public override void CreateFeedBack()
    {

        var obj = FAED.Pop("LineEffect", transform.position, Quaternion.identity);

        var compo = obj.GetComponent<LineEffect>();
        compo.Show();

    }

    public override void EndFeedBack()
    {


    }
}
