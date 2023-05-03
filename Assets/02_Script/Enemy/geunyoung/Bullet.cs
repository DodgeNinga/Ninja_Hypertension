using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    PlayerActionSystem player;
    public float fireSpeed = 4f;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerActionSystem>();
        dir = player.transform.position - transform.position;
        dir = dir.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * fireSpeed * Time.deltaTime;

        if (transform.position.y <= -8 || transform.position.y >= 8)
        {
            Destroy(gameObject);
        }
    }
}
