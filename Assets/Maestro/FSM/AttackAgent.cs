using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAgent : MonoBehaviour
{
    bool isAttacking;
    AIBrain _aiBrain;
    float cool;
    float atkv;
    private void Awake()
    {
        _aiBrain = GetComponent<AIBrain>();
    }

    public void AttackStart(float atkVal, float atkCool)
    {
        if(!isAttacking)
        {
            isAttacking = true;
            atkv = atkVal;
            cool = atkCool;
            StartCoroutine(Attacking());
        }
    }

    public void OnAttackStart()
    {
        Debug.Log(atkv); // ���ϸ����� ����
        //�÷��̾� ������ �ִ� ����
    }

    IEnumerator Attacking()
    {
        _aiBrain.enemyCurrentState = EnemyAIState.Trace;
        yield return new WaitForSeconds(cool);
        isAttacking = false;
    }
}
