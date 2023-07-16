using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperHP : HPObject
{

    private ReaperAnimator animator;
    private AIController controller;

    private void Awake()
    {
        
        animator = GetComponent<ReaperAnimator>();
        controller = GetComponent<AIController>();

    }

    private void Update()
    {
        
        DieChack();

    }

    private void DieChack()
    {



    }

}
