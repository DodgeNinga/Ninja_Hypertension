using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTransition : AITransition
{

    [SerializeField] private Transform target;
    [SerializeField] private Color gizmoColor = Color.black;
    [SerializeField] private float range;
    [SerializeField] private bool reverce;

    public override bool MakeTransition()
    {

        bool value = reverce ? Vector2.Distance(target.position, transform.position) >= range
            : Vector2.Distance(target.position, transform.position) < range;

        return value;

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
