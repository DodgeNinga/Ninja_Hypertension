using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockBackFeedBack : FeedBack
{

    [SerializeField] private GameObject root;

    private PlayerEventController controller;
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;
    private PlayerAnimator animator;
    private PlayerAttack playerAttack;
    private PlayerInvincibility playerInvincibility;
    private PlayerHP playerHP;

    private void Awake()
    {
        
        controller = root.GetComponent<PlayerEventController>();
        rigid = root.GetComponent<Rigidbody2D>();
        spriteRenderer = root.GetComponent<SpriteRenderer>();
        animator = root.GetComponent<PlayerAnimator>();
        playerAttack = root.GetComponent<PlayerAttack>();
        playerInvincibility = root.GetComponent<PlayerInvincibility>();
        playerHP = root.GetComponent<PlayerHP>();

    }

    public override void CreateFeedBack()
    {

        
        animator.SetIsHit(true);
        controller.UnSetAllEvent();
        rigid.velocity = new Vector3(spriteRenderer.flipX ? 3 : -3, 8);
        StartCoroutine(SetKnockBackCo());
        
    }

    public override void EndFeedBack()
    {



    }

    private IEnumerator SetKnockBackCo()
    {

        yield return null;

        playerInvincibility.isInvincibility = true;

        yield return new WaitUntil(() =>
        {

            return rigid.velocity == Vector2.zero;

        });

        if(!playerHP.isDie) controller.SetAllEvent();
        animator.SetIsHit(false);
        playerAttack.ResetAnimeValue();
        playerInvincibility.isInvincibility = false;

    }

}
