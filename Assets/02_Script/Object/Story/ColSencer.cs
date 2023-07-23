using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColSencer : StorySencer
{

    [SerializeField] private float delTime;

    protected bool able;

    public override bool Sencing()
    {

        if(able) gameObject.SetActive(false);

        return able;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.transform.CompareTag("Player")) return;

        FAED.InvokeDelay(() =>
        {

            able = true;

        }, delTime);

    }

}
