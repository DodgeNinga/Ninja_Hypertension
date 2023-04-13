using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLog : PlayerBehaviorRoot
{

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

    }

    public override void AddEvent()
    {

        actionSystem.OnSkillKeyPressEvent += Log;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnSkillKeyPressEvent -= Log;

    }

    public void Log()
    {

        Debug.Log("123");

    }
}
