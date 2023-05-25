using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public enum EnemyAIState
{
    Idle,
    Trace,
    Attack,
    Die
}

public class AIBrain : MonoBehaviour
{
    public EnemyAIState enemyCurrentState;
    public GameObject Player;
    public EnemyData enemyData;

    [SerializeField] private UnityEvent<Transform, float> TraceEvent;
    [SerializeField] private UnityEvent<float, float> AttackEvent;
    [SerializeField] private UnityEvent<EnemyAIState> AnimationEvent;
    [SerializeField] private UnityEvent FlipEvent;

    private Dictionary<EnemyAIState, Action> LogicSelecter = new Dictionary<EnemyAIState, Action>();
    private List<Action> _LogicList = new List<Action>();

    bool isDie = false;

    public float MaxHp;
    public float CurrentHP;

    private void Awake()
    {
        #region 더러운 영수증
        _LogicList.Add(IdleLogic);
        _LogicList.Add(TraceLogic);
        _LogicList.Add(AttackLogic);
        _LogicList.Add(DieLogic);
        #endregion
        Player = GameObject.Find("Player");
        MaxHp = CurrentHP = enemyData.MAXHP;
    }

    void Start()
    {
        int idx = 0;
        foreach (EnemyAIState state in Enum.GetValues(typeof(EnemyAIState)))
        {
            LogicSelecter.Add(state, _LogicList[idx]);
            idx++;
        }
        enemyCurrentState = EnemyAIState.Idle;
    }

    private void IdleLogic()
    {
        if (Vector3.Distance(this.transform.position, Player.transform.position) < enemyData.detectRange)
        {
            enemyCurrentState = EnemyAIState.Trace;
        }
    }

    private void TraceLogic()
    {
        TraceEvent?.Invoke(Player.transform, enemyData.speed);
        if (Vector3.Distance(this.transform.position, Player.transform.position) < enemyData.atkRange)
        {
            enemyCurrentState = EnemyAIState.Attack;
        }
    }

    private void AttackLogic()
    {
        AttackEvent?.Invoke(enemyData.atkValue, enemyData.atkcool);
    }

    private void DieLogic()
    {
        Debug.Log("Die");
    }

    public void CalHPLogic()
    {
        if(CurrentHP <= 0)
        {
            enemyCurrentState = EnemyAIState.Die;
        }
    }

    private void Update()
    {
        if (!isDie)
        {
            LogicSelecter[enemyCurrentState]?.Invoke();
            CalHPLogic();
        }
        AnimationEvent?.Invoke(enemyCurrentState);
    }
}
