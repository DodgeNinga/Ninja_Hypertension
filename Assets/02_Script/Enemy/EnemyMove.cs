using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] bool allDirection;
    [SerializeField] bool chaseJump;
    [SerializeField] float speed;
    [SerializeField] float chasingSpeed;
    [SerializeField] float drbTime; 
    Vector3 playerDir;
    Animator anime;
    ChaseRange ChaseRange;
    bool drb = true;
    int moveDir =-1;
    float delayTime;
    
    Transform player;

    private void Awake()
    {
        anime = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ChaseRange = GetComponentInChildren<ChaseRange>();
        StartCoroutine("ChangeDir");
    }
    IEnumerator ChangeDir()
    {
        while (true)
        {
            yield return new WaitForSeconds(drbTime);
            if (drb)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, 1);
                moveDir *= -1;
            }
        }
    }

    void Update()
    {
        Chase();
    }
    void Chase()
    {
        playerDir = player.position - transform.position;
        playerDir = playerDir.normalized;
        if (ChaseRange.onChaseRange)
        {
            anime.SetBool("fire", true);
            if ((player.position.x - transform.position.x) > 0)
            {
                transform.localScale = new Vector2(-1, 1);
                moveDir = 1;
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
                moveDir = -1;
            }
            if (allDirection)
                transform.position += playerDir * chasingSpeed * Time.deltaTime;
            else
                transform.Translate(Vector2.right *moveDir * chasingSpeed * Time.deltaTime);
        }
        else
        {
            anime.SetBool("fire", false);
            transform.Translate(Vector2.right * moveDir * speed * Time.deltaTime);
        }
    }
}
