using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAgent : MonoBehaviour
{
    AIBrain _aiBrain;
    float cool;
    float atkv;
    private void Awake()
    {
        _aiBrain = GetComponent<AIBrain>();
    }

    public void AttackStart(float atkVal, float atkCool)
    {
        if(!_aiBrain.isAttacking)
        {
            _aiBrain.isAttacking = true;
            atkv = atkVal;
            cool = atkCool;
        }
    }

    public void OnAttackStart()
    {
        Debug.Log(atkv); // ���ϸ����� ����
        //�÷��̾� ������ �ִ� ����
        _aiBrain.enemyCurrentState = EnemyAIState.Idle;
    }

    public void OnAttackEnd()
    {
        
        StartCoroutine(Attacking());
    }

    IEnumerator Attacking()
    {
        
        yield return new WaitForSeconds(cool);
        _aiBrain.isAttacking = false;
        _aiBrain.enemyCurrentState = EnemyAIState.Trace;
    }
}
