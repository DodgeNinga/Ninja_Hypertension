using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdObject : MonoBehaviour
{

    private readonly int MoveTriggerHash = Animator.StringToHash("MoveTrigger");

    [SerializeField] private Vector2 moveDir;

    private Animator animator;
    private Rigidbody2D rigid;

    private void Awake()
    {
        
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    public void MoveStart()
    {

        rigid.velocity = moveDir;
        animator.SetTrigger(MoveTriggerHash);

    }

}
