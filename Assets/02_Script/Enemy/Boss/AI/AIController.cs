using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    [SerializeField] private AIState currentState;
    [field:SerializeField] public bool controllAble { get; set; } = true;

    public Rigidbody2D enemyRigid { get; private set; }

    private void Awake()
    {
        
        enemyRigid = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {

        if (!controllAble) return;

        currentState.EnterState();

    }

    private void Update()
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
