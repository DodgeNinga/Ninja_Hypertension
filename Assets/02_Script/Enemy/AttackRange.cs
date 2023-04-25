using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public bool onAttackRange = false;
    public float attackRange;
    Collider2D col;
    public float colX;
    public float colY;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        col.offset = new Vector3(colX, colY, 0);
        GetComponent<CircleCollider2D>().radius = attackRange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onAttackRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onAttackRange = false;
        }
    }
}
