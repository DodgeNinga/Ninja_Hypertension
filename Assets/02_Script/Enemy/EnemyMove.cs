using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float delayTime;
    [SerializeField] float speed;
    [SerializeField] float chasingSpeed;
    int flip = -1;
    int moveDir = -1;
    Vector3 direction;
    EnemyChase EC;
    Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        EC = FindObjectOfType<EnemyChase>().GetComponent<EnemyChase>();
    }
    IEnumerator ChangeDir()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayTime);
            transform.localScale = new Vector2(transform.localScale.x*flip, 1);
            moveDir *= -1;
        }
    }

    void Update()
    {
        direction = player.position - transform.position;
        direction = direction.normalized;
        if (EC.chasing == false)
        {
            transform.Translate(Vector3.right * speed * moveDir * Time.deltaTime);
            flip = moveDir;
        }
        else
        {
            transform.position += direction * chasingSpeed * Time.deltaTime;
            flip = 1;
        }
    }
}
