using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : MonoBehaviour
{

    private List<AITransition> transitions = new List<AITransition>();
    public abstract void EnterState(); 
    public abstract void UpdateState();
    public abstract void ExitState();

}
