using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolemHP : HPObject
{

    [SerializeField] private Slider slider;
    [SerializeField] private float maxHP;

    private void Awake()
    {

        HP = maxHP;

    }

    private void Update()
    {

        slider.value = HP / maxHP;

    }

}
