using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdObject : MonoBehaviour
{

    [SerializeField] private Vector2 moveDir;

    private Rigidbody2D rigid;

    private void Awake()
    {
        
        rigid = GetComponent<Rigidbody2D>();

    }

    public void SetStart()
    {

        rigid.velocity = moveDir;

    }

}
