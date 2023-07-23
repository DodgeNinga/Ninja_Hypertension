using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PlayerHP : HPObject
{

    [SerializeField] private float maxHP;
    [SerializeField] private float dotDelTime;
    [SerializeField] private float dotDel;
    [SerializeField] private Slider slider;
    [SerializeField] private UnityEvent dieEvent;

    private PlayerInvincibility invincibility;

    public bool isDie { get; private set; }
    public float GetHPLV => HP / maxHP;

    private void Awake()
    {

        HP = maxHP / 2;
        SetSlider();
        invincibility = FindObjectOfType<PlayerInvincibility>();

    }

    private void Start()
    {

        StartCoroutine(DotDelCo());

    }
    private void Update()
    {

        DieChack();

    }

    private void DieChack()
    {

        if((HP >= maxHP || HP <= 0) && !isDie)
        {

            isDie = true;
            StopAllCoroutines();
            dieEvent?.Invoke();

        }

    }

    private void SetSlider()
    {

        if (slider == null) return;

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

        if (invincibility.isInvincibility) return;

        base.TakeDamage(damage);
        SetSlider();

        var popUp = FAED.Pop("DamageText", transform.position, Quaternion.identity).GetComponent<DamageText>();
        popUp.SetText(damage);

    }


    public void TakeDotDel(float damage)
    {

        base.TakeDamage(damage);
        SetSlider();

    }

    private IEnumerator DotDelCo()
    {

        while(true) 
        {

            yield return new WaitForSeconds(dotDelTime);
            TakeDotDel(dotDel);

        }

    }

    public void DIEEVT()
    {

        SceneManager.LoadScene("Lobby");

    }

}
