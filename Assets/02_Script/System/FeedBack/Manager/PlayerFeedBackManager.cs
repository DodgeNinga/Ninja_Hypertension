using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedBackManager : FeedBackManager
{

    private PlayerInvincibility invincibility;
    private PlayerHP playerHP;

    private void Awake()
    {

        playerHP = FindObjectOfType<PlayerHP>();
        invincibility = FindObjectOfType<PlayerInvincibility>();

    }

    public override void PlayFeedback(string state)
    {

        if (invincibility.isInvincibility || playerHP.isDie) return;
        base.PlayFeedback(state);

    }

}
