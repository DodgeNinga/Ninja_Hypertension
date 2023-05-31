using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAgent : MonoBehaviour
{
    SpriteRenderer sr;
    AIBrain ab;
    Animator ani;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        ab = GetComponent<AIBrain>();
        ani = GetComponent<Animator>();
    }

    public void Die()
    {
        
        ani.ResetTrigger("Die");
        sr.sprite = ab.enemyData.dieSprite;
    }
}
