using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockBackFeedBack : FeedBack
{

    [SerializeField] private GameObject root;

    private PlayerEventController controller;
    private Rigidbody2D rigid;

    private void Awake()
    {
        
        controller = root.GetComponent<PlayerEventController>();
        rigid = root.GetComponent<Rigidbody2D>();

    }

    public override void CreateFeedBack()
    {

        controller.UnSetAllEvent();

    }

    public override void EndFeedBack()
    {



    }

    private IEnumerator SetKnockBackCo()
    {

        yield return new WaitUntil(() =>
        {

            return rigid.velocity == Vector2.zero;

        });

    }

}
