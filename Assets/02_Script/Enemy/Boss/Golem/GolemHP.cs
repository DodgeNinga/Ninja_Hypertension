using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolemHP : HPObject
{

    [SerializeField] private Slider slider;
    [SerializeField] private Transform sliderMainTrans;
    [SerializeField] private float maxHP;

    private void Awake()
    {

        HP = maxHP;

    }

    private void Update()
    {

        slider.value = HP / maxHP;

    }

    public void SetXScale(float value)
    {

        sliderMainTrans.transform.localScale = new Vector3(value, 1, 1);

    }

}
