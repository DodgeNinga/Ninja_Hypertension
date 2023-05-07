using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    [SerializeField] private AIState currentState;

    public Rigidbody2D enemyRigid { get; private set; }
    public bool controllAble { get; set; }

    private void Awake()
    {
        
        enemyRigid = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {

        currentState.EnterState();

    }

    private void Update()
    {
        
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
