using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpell : MonoBehaviour
{

    private Transform target;

    private void Awake()
    {

        target = GameObject.Find("Player").transform;

    }

    public void UseSkill()
    {

        for(int i = 0; i < 3; i++) 
        { 

            FAED.Pop("MonsterSpell", target.position + new Vector3(Random.Range(-5f, 5f), 1.5f), Quaternion.identity);
        
        }


    }

}
