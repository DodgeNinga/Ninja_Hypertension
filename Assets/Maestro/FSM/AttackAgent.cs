using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAgent : MonoBehaviour
{
    bool isAttacking;
    AIBrain _brain;

    private void Awake()
    {
        _brain = GetComponentInParent<AIBrain>();
    }

    public void AttackStart(float atkVal, float atkCool)
    {
        if(!isAttacking)
        {
            isAttacking = true;
            Debug.Log(atkVal); // 플레이어 찾아서 데미지 주기
            _brain.
            StartCoroutine(Attacking(atkCool));
        }
    }

    IEnumerator Attacking(float cool)
    {
        yield return new WaitForSeconds(cool);
        isAttacking = false;
    }
}
