using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AITransition : MonoBehaviour
{

    public AIState nextState;

    public abstract bool MakeTransition();

}
