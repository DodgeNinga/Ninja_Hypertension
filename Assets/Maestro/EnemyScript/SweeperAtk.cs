using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweeperAtk : AttackAgent
{
    Animator _animator;
    [SerializeField] private AnimatorOverrideController _sweeperOvCon;
    [SerializeField] private AnimationClip[] _attackClipArr;

    public override void AttackStart(float atkVal, float atkCool)
    {
        int random = Random.Range(0, 2);
        Debug.Log(random);
        _sweeperOvCon["AtkAnim"] = _attackClipArr[random];
        _animator = GetComponent<Animator>();
        _animator.runtimeAnimatorController = _sweeperOvCon;
        base.AttackStart(atkVal, atkCool);
    }
}
