using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : PlayerBehaviorRoot
{

    [SerializeField] private float dashPower;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

    }

    private void Dash()
    { 

        //if (!jumpCol.isGround) return;

        rigid.velocity += Vector2.up * dashPower;
        Debug.Log("1");

    }

    public override void AddEvent()
    {

        actionSystem.OnDashKeyPressEvent += Dash;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnDashKeyPressEvent -= Dash;

    }
}
