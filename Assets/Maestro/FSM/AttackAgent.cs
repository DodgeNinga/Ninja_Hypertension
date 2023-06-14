using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAgent : MonoBehaviour
{
    protected GameObject Player;
    AIBrain _aiBrain;
    protected float cool;
    protected float atkv;
    protected void Awake()
    {
        Player = GameObject.Find("Player");
        _aiBrain = GetComponent<AIBrain>();
    }

    public virtual void AttackStart(float atkVal, float atkCool)
    {
        if(!_aiBrain.isAttacking)
        {
            _aiBrain.isAttacking = true;
            atkv = atkVal;
            cool = atkCool;
        }
    }

    public virtual void OnAttackStart()
    {
        if (Vector3.Distance(this.transform.position, _aiBrain.Player.transform.position) < _aiBrain.enemyData.atkRange)
        {
            Debug.Log(atkv);
        }
         // 에니메이터 실행
        //플레이어 데미지 주는 로직
    }

    public void OnAttackEnd()
    {
        _aiBrain.enemyCurrentState = EnemyAIState.Idle;
        StartCoroutine(Attacking());
    }

    IEnumerator Attacking()
    {
        yield return new WaitForSeconds(cool);
        _aiBrain.isAttacking = false;
        _aiBrain.enemyCurrentState = EnemyAIState.Trace;
    }
}
