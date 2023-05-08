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

        StartCoroutine(MoveCo());
        animator.SetTrigger(MoveTriggerHash);

    }

    private IEnumerator MoveCo()
    {

        var stertPower = moveDir / 2;

        float per = 0;

        while(per < 1)
        {

            yield return null;

            per += Time.deltaTime;
            rigid.velocity = Vector2.Lerp(stertPower, moveDir, per);

        }

    }

}
