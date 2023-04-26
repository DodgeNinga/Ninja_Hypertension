using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float power;
    public float delayTime = 0f;

    bool playerAttack;
    bool playerAttackRunning;

    void Start()
    {
        playerAttack = false;
        playerAttackRunning = false;
    }

    void Update()
    {
        
    }

    private void onTriggerEnterAndStayMethod(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !playerAttack && !playerAttackRunning)
        {
            playerAttack = true;
            playerAttackRunning = true;
            StartCoroutine("PlayerAttack", delayTime);
            Debug.Log("attack");
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEnterAndStayMethod(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        onTriggerEnterAndStayMethod(collision);
    }

    IEnumerator PlayerAttack(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        playerAttack = false;
        playerAttackRunning = false;

        Debug.Log("isNotAttacked");
    }
}
