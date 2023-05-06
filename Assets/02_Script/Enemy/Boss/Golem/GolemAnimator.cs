using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAnimator : MonoBehaviour
{

    private readonly int IsMoveHash = Animator.StringToHash("IsMove");

    private Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();

    }

    public void SetIsMove(bool value) => animator.SetBool(IsMoveHash, value);

}
