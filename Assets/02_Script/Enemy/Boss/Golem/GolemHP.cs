using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GolemHP : HPObject
{

    [SerializeField] private Slider slider;
    [SerializeField] private Transform sliderMainTrans;
    [SerializeField] private float maxHP;

    private void Update()
    {

        slider.value = HP / maxHP;
        DieChack();

    }

    public void SetXScale(float value)
    {

        sliderMainTrans.transform.localScale = new Vector3(value, 1, 1);

    }

    private GolemAnimator animator;
    private AIController controller;
    private bool isD;

    private void Awake()
    {

        animator = GetComponent<GolemAnimator>();
        controller = GetComponent<AIController>();
        HP = maxHP;

    }

    private void DieChack()
    {

        if (isD) return;

        if (HP <= 0)
        {

            controller.controllAble = false;
            FAED.InvokeDelay(DIEEVT, 0.3f);
            isD = true;

        }

    }

    public void DIEEVT()
    {

        PlayerPrefs.SetInt("GC", int.MaxValue);
        SceneManager.LoadScene("Lobby");

    }

}
