using Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PlayerBehaviorRoot : PlayerRoot, IEventObject
{

    public abstract void AddEvent();

    public abstract void RemoveEvent();

}
