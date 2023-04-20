using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float drbTime;
    [SerializeField] float speed;
    [SerializeField] float chasingSpeed;
    [SerializeField] bool chasing;
    Animator anime;
    float delayTime;
    bool drb = true;
    ChaseRange ChaseRange;
    Vector3 playerDir;
    int moveDir =-1;
    
    Transform player;

    private void Awake()
    {
        anime = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ChaseRange = FindObjectOfType<ChaseRange>().GetComponent<ChaseRange>();
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
        if (chasing) Chase();
    }
    void Chase()
    {
        playerDir = player.position - transform.position;
        playerDir = playerDir.normalized;
        if (ChaseRange.onRange)
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
            transform.position += playerDir * chasingSpeed * Time.deltaTime;
        }
        else
        {
            anime.SetBool("fire", false);
            transform.Translate(Vector2.right * moveDir * speed * Time.deltaTime);
        }
    }
}
