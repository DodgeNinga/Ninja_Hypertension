using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeTransition : AITransition
{

    [SerializeField] private Transform target;
    [SerializeField] private Color gizmoColor = Color.black;
    [SerializeField] private float range;
    [SerializeField] private bool reverce;

    private GolemAttackState state;

    private void Awake()
    {
        
        state = FindObjectOfType<GolemAttackState>();

    }

    public override bool MakeTransition()
    {

        bool value = reverce ? Vector2.Distance(target.position, transform.position) >= range
            : Vector2.Distance(target.position, transform.position) < range;

        return value && !state.isCoolDown;

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {

        var old = Gizmos.color;
        Gizmos.color = gizmoColor;

        Gizmos.DrawWireSphere(transform.position, range);

        Gizmos.color = old;

    }

#endif

}
