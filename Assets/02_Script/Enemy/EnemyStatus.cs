
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : HPObject
{
    public float damage = 1000f;
    public float hp = 2000f; 
    void Start()
    {
        HP = hp;
    }

    void Update()
    {
        
    }
}
