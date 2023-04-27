using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyAttack : HPObject
{
    [SerializeField] float power = 10;
    public float delayTime = 0f;
    public bool isAttack = false;

    private void Start()
    {
        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        while (true)
        {
            if (isAttack == true)
            {
                TakeDamage(power);
                Debug.Log("Attack");
                yield return new WaitForSeconds(delayTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isAttack = false;
    }
}