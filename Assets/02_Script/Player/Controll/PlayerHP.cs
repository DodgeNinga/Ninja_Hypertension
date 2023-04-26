using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHP : HPObject
{

    [SerializeField] private float maxHP;
    [SerializeField] private Slider slider;
    [SerializeField] private UnityEvent dieEvent;

    private void Awake()
    {

        HP = maxHP / 2;

    }

    private void DieChack()
    {

        if(HP >= maxHP || HP <= 0)
        {

            dieEvent?.Invoke();

        }

    }

    private void SetSlider()
    {



    }

    public override void HealingHP(float healPoint)
    {

        base.HealingHP(healPoint);
        DieChack();

    }

    public override void TakeDamage(float damage)
    {

        base.TakeDamage(damage);
        DieChack();

    }

}
