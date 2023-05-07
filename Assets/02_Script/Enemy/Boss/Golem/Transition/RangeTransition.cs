using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTransition : AITransition
{

    [SerializeField] private Transform target;
    [SerializeField] private float range;
    [SerializeField] private bool reverce;

    public override bool MakeTransition()
    {

        bool value = Vector2.Distance(target.position, transform.position) < range;

        return reverce ? !value : value;

    }

}
