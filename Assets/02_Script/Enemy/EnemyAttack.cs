using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyAttack : HPObject
{
    public bool onAttackRange = false;
    [SerializeField] float power = 10;
    public float delayTime = 0f;
    public bool coolTime = true;
    public bool coolRunning = false;
    
    IEnumerator PlayerAttack()
    {
        yield return new WaitUntil(() => 
        {

            return coolTime;

        });
        while(true)
        {
            TakeDamage(power);
            Debug.Log("Attack");
            yield return new WaitForSeconds(delayTime);
        }
    }
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(delayTime);
        coolRunning = false;
        coolTime = true; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine("PlayerAttack");
            onAttackRange = true;
            Debug.Log("Start");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine("PlayerAttack");
            coolTime = false;
            onAttackRange = false;
            if(!coolRunning)
            {
                StartCoroutine("CoolTime");
                coolRunning = true;
            }
            Debug.Log("Stop");
        }
    }
}
