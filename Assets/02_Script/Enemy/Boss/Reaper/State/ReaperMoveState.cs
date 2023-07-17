using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperMoveState : AIState
{

    [SerializeField] private float moveSpeed = 3f;

    private Transform target;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;

    protected override void Awake()
    {

        base.Awake();

        target = GameObject.Find("Player").transform;
        spriteRenderer = controller.GetComponent<SpriteRenderer>();
        rigid = controller.GetComponent<Rigidbody2D>();

    }

    public override void EnterState()
    {



    }

    public override void ExitState()
    {

        rigid.velocity = Vector3.zero;

    }

    public override void UpdateState()
    {

        float crtSpeed = (transform.position.x - target.position.x) > 0 ? -moveSpeed : moveSpeed;

        rigid.velocity = new Vector2(crtSpeed, 0);
        spriteRenderer.flipX = (transform.position.x - target.position.x) > 0;

    }

}
