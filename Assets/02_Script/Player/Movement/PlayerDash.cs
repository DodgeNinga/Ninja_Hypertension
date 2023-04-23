using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : PlayerBehaviorRoot
{

    [SerializeField] private float dashPower;
    [SerializeField] private float dashTime;
    [SerializeField] private List<PlayerBehaviorRoot> manageBehaviors = new List<PlayerBehaviorRoot>();

    private float originGravityScale;
    private AddGravity gravity;

    public bool dashAble { get; set; } = true;

    protected override void Awake()
    {

        base.Awake();

        gravity = GetComponent<AddGravity>();
        AddEvent();

        originGravityScale = rigid.gravityScale;

    }

    private void Dash()
    {

        rigid.gravityScale = 0;
        gravity.onGravity = false;

        foreach(var item in manageBehaviors) 
        {
        
            item.RemoveEvent();

        }

        float curDashPower = spriteRenderer.flipX ? -dashPower : dashPower;

        rigid.velocity = new Vector2(curDashPower, 0);

        StartCoroutine(DashEndCo());

    }

    private void DashEnd()
    {

        gravity.onGravity = true;
        rigid.gravityScale = originGravityScale;

        foreach(var item in manageBehaviors)
        {

            item.AddEvent();

        }

    }

    public override void AddEvent()
    {

        actionSystem.OnDashKeyPressEvent += Dash;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnDashKeyPressEvent -= Dash;

    }

    private IEnumerator DashEndCo()
    {

        yield return new WaitForSeconds(dashTime);

        DashEnd();

    }

}
