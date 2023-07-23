using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : HPObject
{

    [SerializeField] private float maxHP;

    private AIBrain ai;

    private void Awake()
    {

        HP = maxHP;
        ai = GetComponent<AIBrain>();

    }

    private void Update()
    {
        
        if(HP <= 0)
        {

            ai.enemyCurrentState = EnemyAIState.Die;

        }

    }

}
