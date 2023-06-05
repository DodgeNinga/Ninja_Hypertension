using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : PlayerBehaviorRoot
{


    protected override void Awake()
    {
        
        base.Awake();

        AddEvent();

    }

    private void Rolling()
    {

        if (jumpCol.isGround) return;

    }

    public override void AddEvent()
    {

        actionSystem.OnRollingAttaclKeyPressEvent += Rolling;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnRollingAttaclKeyPressEvent -= Rolling;

    }
}
