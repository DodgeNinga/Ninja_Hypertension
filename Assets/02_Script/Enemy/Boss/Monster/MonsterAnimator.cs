using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimator : MonoBehaviour
{

    private readonly int AttackTriggerHash = Animator.StringToHash("AttackTrigger");
    private readonly int AttackEndTriggerHash = Animator.StringToHash("AttackEndTrigger");
    private readonly int SpellTriggerHash = Animator.StringToHash("SpellTrigger");
    private readonly int SpellEndTriggerHash = Animator.StringToHash("SpellEndTrigger");
    private readonly int DieTriggerHash = Animator.StringToHash("DieTrigger");

    private Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();

    }

    public void SetAttackTrigger() => animator.SetTrigger(AttackTriggerHash);
    public void SetAttackEndTrigger() => animator.SetTrigger(AttackEndTriggerHash);
    public void SetSpellTrigger() => animator.SetTrigger(SpellTriggerHash);
    public void SetSpellEndTrigger()=> animator.SetTrigger(SpellEndTriggerHash);
    public void SetDieTrigger() => animator.SetTrigger(DieTriggerHash);

}
