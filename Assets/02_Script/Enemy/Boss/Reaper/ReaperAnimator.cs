using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperAnimator : MonoBehaviour
{

    private readonly int DieTriggerHash = Animator.StringToHash("DieTrigger");
    private readonly int AttackTriggerHash = Animator.StringToHash("AttackTrigger");
    private readonly int RoarTriggerHash = Animator.StringToHash("RoarTrigger");
    private readonly int RoarEndTriggerHash = Animator.StringToHash("RoarEndTrigger");
    private readonly int AttackEndTriggerHash = Animator.StringToHash("AttackEndTrigger");

    private Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();

    }

    public void SetDieTrigger() => animator.SetTrigger(DieTriggerHash);
    public void SetAttackTrigger() => animator.SetTrigger(AttackTriggerHash);
    public void SetRoarTrigger() => animator.SetTrigger(RoarTriggerHash);
    public void SetRoarEndTrigger() => animator.SetTrigger(RoarEndTriggerHash);
    public void SetAttackEndTrigger() => animator.SetTrigger(AttackEndTriggerHash);

}
