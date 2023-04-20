using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerBehaviorRoot
{

    [SerializeField] private float comboAbleTime = 0.2f;

    private int comboCnt;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

    }

    public override void AddEvent()
    {
        


    }

    public override void RemoveEvent()
    {
        


    }
}
