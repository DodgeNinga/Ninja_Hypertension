using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] bool allDirection;
    [SerializeField] bool chaseJump;
    [SerializeField] bool ignoreCol;
    [SerializeField] float speed;
    [SerializeField] float chasingSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] float drbTime;
    Rigidbody2D rigid;
    Vector3 playerDir;
    ChaseRange ChaseRange;
    ChaseStopRange ChaseStopRange;
    EnemyDG EnemyDG;
    bool drb = true;
    int moveDir =-1;
    float delayTime;
    
    Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ChaseRange = GetComponentInChildren<ChaseRange>();
        ChaseStopRange = GetComponentInChildren<ChaseStopRange>();
        if(chaseJump)
            EnemyDG = GetComponentInChildren<EnemyDG>();
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine("ChangeDir");
        jumpPower *= 10;
        if (ignoreCol)
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Ground"), true);
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
            if (player.position.x -0.1f > transform.position.x)
            {
                transform.localScale = new Vector2(-1, 1);
                moveDir = 1;
            }
            else if (transform.position.x-0.1f > player.position.x)
            {
                transform.localScale = new Vector2(1, 1);
                moveDir = -1;
            }
            else
                moveDir = 0;
            if (!ChaseStopRange.onChaseStopRange) {
                if (allDirection)
                    transform.position += playerDir * chasingSpeed * Time.deltaTime;
                else
                    transform.Translate(Vector2.right * moveDir * chasingSpeed * Time.deltaTime);
            }
            if (chaseJump&&(EnemyDG.onGround && (player.position.y - 1 > transform.position.y||ChaseStopRange.onChaseStopRange)))
                Jump();
        }
        else
        {
            transform.Translate(Vector2.right * moveDir * speed * Time.deltaTime);
        }
    }
    void Jump()
    {
        rigid.AddForce(new Vector2(0, jumpPower));
    }
}
