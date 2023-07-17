using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSkill : MonoBehaviour
{

    [SerializeField] private LineEffect lineEffect;
    [SerializeField] private GameObject waringLine;

    public void SetSkill()
    {

        lineEffect.gameObject.SetActive(true);
        waringLine.SetActive(false);
        lineEffect.Show();

        var obj = Physics2D.OverlapBox(transform.position, new Vector2(10, 0.4f), transform.eulerAngles.z, LayerMask.GetMask("Player"));

        if(obj != null)
        {

            obj.GetComponent<HPObject>()?.TakeDamage(10);
            obj.GetComponent<FeedBackManager>()?.PlayFeedback("Hit");

        }

        FAED.InvokeDelay(() =>
        {

            lineEffect.gameObject.SetActive(false);
            waringLine.gameObject.SetActive(true);

            FAED.Push(gameObject);

        }, 0.5f);

    }

}