using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemMoveState : AIState
{

    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rigid;

    protected override void Awake()
    {
        
        rigid = controller.GetComponent<Rigidbody2D>();

    }

    public override void EnterState()
    {
        


    }

    public override void ExitState()
    {



    }

    public override void UpdateState()
    {

        float crtSpeed = (transform.position.x - target.position.x) > 0 ? moveSpeed : -moveSpeed;

        rigid.velocity = new Vector2(crtSpeed, 0);

    }
}
