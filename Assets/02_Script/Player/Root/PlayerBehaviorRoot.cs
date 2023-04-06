using Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBehaviorRoot : PlayerRoot, IEventObject
{

    public abstract void AddEvent();

    public abstract void RemoveEvent();

}
