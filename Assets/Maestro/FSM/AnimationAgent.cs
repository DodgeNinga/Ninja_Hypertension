using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAgent : MonoBehaviour
{
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimation(EnemyAIState state)
    {
        switch(state)
        {
            case EnemyAIState.Idle:
                _animator.SetBool("isWalk", false);
                _animator.SetBool("isAttack", false);
                break;
            case EnemyAIState.Attack:
                _animator.SetBool("isWalk", false);
                _animator.SetBool("isAttack", true);
                break;
            case EnemyAIState.Trace:
                _animator.SetBool("isWalk", true);
                _animator.SetBool("isAttack", false);
                break;
            case EnemyAIState.Die:
                _animator.SetTrigger("Die");
                break;
            default:
                break;
        }
    }    
}
