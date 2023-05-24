using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EnemyAIState
{
    Idle,
    trace,
    attack,
    die
}

public class AIBrain : MonoBehaviour
{
    [SerializeField] protected EnemyAIState enemyCurrentState;
    public GameObject Player;
    public EnemyData enemyData;

    [SerializeField] private UnityEvent TraceEvent;
    [SerializeField] private UnityEvent<float, float> AttackEvent;
    private void Awake()
    {
        Player = GameObject.Find("Player");
    }

    void Start()
    {
        enemyCurrentState = EnemyAIState.Idle;
    }

    void Update()
    {
        if(Vector3.Distance(this.transform.position, Player.transform.position) < enemyData.detectRange && 
            enemyCurrentState == EnemyAIState.Idle)
        {
            enemyCurrentState = EnemyAIState.trace;
        }

        if(enemyCurrentState == EnemyAIState.trace)
        {
            TraceEvent?.Invoke();
        }

        if(Vector3.Distance(this.transform.position, Player.transform.position) < enemyData.atkRange
            && enemyCurrentState == EnemyAIState.trace)
        {
            enemyCurrentState = EnemyAIState.attack;
        }

        if(enemyCurrentState == EnemyAIState.attack)
        {
            AttackEvent?.Invoke(enemyData.atkValue, enemyData.atkcool);
            enemyCurrentState = EnemyAIState.trace;
        }
    }

    
}
