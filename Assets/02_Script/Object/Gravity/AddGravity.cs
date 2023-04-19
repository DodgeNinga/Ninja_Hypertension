using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGravity : MonoBehaviour
{

    [SerializeField] private float gravityPower = 9.8f;

    private Rigidbody2D rigid;
    private JumpCol jumpCol;

    private void Awake()
    {
        
        jumpCol = transform.Find("JumpCol").GetComponent<JumpCol>();
        rigid = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {

        if (!jumpCol.isGround)
        {

            rigid.velocity -= new Vector2(0, gravityPower * Time.deltaTime);

        }

    }

}