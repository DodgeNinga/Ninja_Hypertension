using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : MonoBehaviour
{

    private List<AITransition> transitions = new List<AITransition>();
    private AIController controller;

    protected virtual void Awake()
    {

        GetComponentsInChildren(transitions);
        controller = transform.parent.parent.GetComponent<AIController>();

    }

    public abstract void EnterState(); 
    public abstract void UpdateState();
    public abstract void ExitState();

}
