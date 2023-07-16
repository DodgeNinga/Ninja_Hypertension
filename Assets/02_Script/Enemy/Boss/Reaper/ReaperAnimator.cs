using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperAnimator : MonoBehaviour
{

    private Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();

    }

}
