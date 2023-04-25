using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float power;
    public float delayTime = 0f;
    bool playerAttack;

    bool _isPlayerAttacked;
    bool _isPlayerAttackedMethodRunning;

    void Start()
    {
        _isPlayerAttacked = false;
        _isPlayerAttackedMethodRunning = false;
    }

    void Update()
    {
        
    }

    private void onTriggerEnterAndStayMethod(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !_isPlayerAttacked && !_isPlayerAttackedMethodRunning)
        {
            _isPlayerAttacked = true;
            _isPlayerAttackedMethodRunning = true;
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
        _isPlayerAttacked = false;
        _isPlayerAttackedMethodRunning = false;

        Debug.Log("isNotAttacked");
    }
}
