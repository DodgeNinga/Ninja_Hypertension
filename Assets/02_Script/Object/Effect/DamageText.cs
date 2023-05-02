using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{

    private TMP_Text tmpText;

    private void Awake()
    {
        
        tmpText = GetComponent<TMP_Text>();

    }

    public void SetText(float text)
    {

        tmpText.text = ((int)text).ToString();

        FAED.InvokeDelay(() =>
        {

            FAED.Push(gameObject);

        }, 1f);

    }

}
