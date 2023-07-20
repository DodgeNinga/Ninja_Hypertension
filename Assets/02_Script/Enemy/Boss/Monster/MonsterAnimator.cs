using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimator : MonoBehaviour
{

    private readonly int AttackTriggerHash = Animator.StringToHash("AttackTrigger");
    private readonly int SpellTriggerHash = Animator.StringToHash("SpellTrigger");
    private readonly int DieTriggerHash = Animator.StringToHash("DieTrigger");

    private Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();

    }

}
