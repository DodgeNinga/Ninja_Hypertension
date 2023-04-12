using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPObject : MonoBehaviour
{

    public float HP { get; protected set; }

    public virtual void TakeDamage(float damage) 
    { 
        
        HP -= damage;

    }

    public virtual void HealingHP(float healPoint)  
    { 
        
        HP += healPoint;

    }

}
