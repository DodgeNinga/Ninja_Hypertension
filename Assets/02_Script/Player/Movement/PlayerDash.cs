using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : PlayerBehaviorRoot
{

    public bool dashAble { get; set; } = true;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

    }

    private void Dash()
    {



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
