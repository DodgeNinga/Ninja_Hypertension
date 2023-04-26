using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHP : HPObject
{

    [SerializeField] private float maxHP;
    [SerializeField] private float dotDelTime;
    [SerializeField] private float dotDel;
    [SerializeField] private Slider slider;
    [SerializeField] private UnityEvent dieEvent;

    private void Awake()
    {

        HP = maxHP / 2;

    }

    private void Start()
    {

        StartCoroutine(DotDelCo());

    }

    private void DieChack()
    {

        if(HP >= maxHP || HP <= 0)
        {

            StopAllCoroutines();
            dieEvent?.Invoke();

        }

    }

    private void SetSlider()
    {

        slider.value = HP / maxHP;

    }

    public override void HealingHP(float healPoint)
    {

        base.HealingHP(healPoint);
        DieChack();
        SetSlider();

    }

    public override void TakeDamage(float damage)
    {

        base.TakeDamage(damage);
        DieChack();
        SetSlider();

    }

    private IEnumerator DotDelCo()
    {

        while(true) 
        {

            yield return new WaitForSeconds(dotDelTime);
            TakeDamage(dotDel);

        }

    }

}
