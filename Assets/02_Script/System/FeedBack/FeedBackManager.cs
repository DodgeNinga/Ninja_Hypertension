using Struct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackManager : MonoBehaviour
{

    [SerializeField] private List<FeedBackManage> manegeFeedbacks = new List<FeedBackManage>();

    public virtual void PlayFeedback(string state)
    {

        var crtFeedBack = manegeFeedbacks.Find(x => x.feedbackState == state);

        if (crtFeedBack.feedbackState == "") return;

        foreach(var item in crtFeedBack.feedBack)
        {

            item.CreateFeedBack();

        }

    }

    public virtual void EndFeedback(string state)
    {

        var crtFeedBack = manegeFeedbacks.Find(x => x.feedbackState == state);

        if (crtFeedBack.feedbackState == "") return;

        foreach (var item in crtFeedBack.feedBack)
        {

            item.EndFeedBack();

        }

    }

}
