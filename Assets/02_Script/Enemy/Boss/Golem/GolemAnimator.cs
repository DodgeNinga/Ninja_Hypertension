using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAnimator : MonoBehaviour
{

    private readonly int IsMoveHash = Animator.StringToHash("IsMove");
    private readonly int WakeUpHash = Animator.StringToHash("WakeUp");
    private readonly int IsAttackHash = Animator.StringToHash("IsAttack");
    private readonly int AttackTriggerHash = Animator.StringToHash("AttackTrigger");
    private readonly int AttackSelectIntHash = Animator.StringToHash("AttackSelectInt");
    private readonly int IsSpinHash = Animator.StringToHash("IsSpin");
    private readonly int SpinTriggerHash = Animator.StringToHash("SpinTrigger");

    private Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();

    }

    public void SetIsMove(bool value) => animator.SetBool(IsMoveHash, value);
    public void SetIsAttack(bool value) => animator.SetBool(IsAttackHash, value);
    public void SetIsSpin(bool value) => animator.SetBool(IsSpinHash, value);
    public void SetAttackSelectInt(int value) => animator.SetInteger(AttackSelectIntHash, value);
    public void SetWakeUp() => animator.SetTrigger(WakeUpHash);
    public void SetAttackTrigger() => animator.SetTrigger(AttackTriggerHash);
    public void SetSpinTrigger() => animator.SetTrigger(SpinTriggerHash);

}
