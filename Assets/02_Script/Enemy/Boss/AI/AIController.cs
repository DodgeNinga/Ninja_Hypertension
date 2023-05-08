using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    [SerializeField] protected AIState currentState;
    [field:SerializeField] public bool controllAble { get; set; } = true;

    public Rigidbody2D enemyRigid { get; private set; }

    protected virtual void Awake()
    {
        
        enemyRigid = GetComponent<Rigidbody2D>();

    }

    protected virtual void Start()
    {

        if (!controllAble) return;

        currentState.EnterState();

    }

    protected virtual void Update()
    {

        if (!controllAble) return;

        currentState.UpdateState();
        currentState.SettingTransition();

    }

    public void ChangeState(AIState state)
    {

        currentState.ExitState();
        currentState = state;

        currentState.EnterState();

    }

}
