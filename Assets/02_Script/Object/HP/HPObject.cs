using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

public class HPObject : MonoBehaviour, IHpObject
{

    public float HP { get; protected set; }
    public void TakeDamage(float damage) { }
    public void HealingHP(float healPoint) { }

}
