using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionObject : MonoBehaviour
{

    public LayerMask changeLayer;
    public abstract void InteractionEvent();

}
