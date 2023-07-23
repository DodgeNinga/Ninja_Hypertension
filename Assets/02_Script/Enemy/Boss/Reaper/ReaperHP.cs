using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReaperHP : HPObject
{

    [SerializeField] private Slider slider;
    [SerializeField] private float maxHP;
    private ReaperAnimator animator;
    private AIController controller;
    private bool isD;

    private void Awake()
    {
        
        animator = GetComponent<ReaperAnimator>();
        controller = GetComponent<AIController>();
        HP = maxHP;

    }

    private void Update()
    {
        
        DieChack();
        slider.value = HP / maxHP;

    }

    private void DieChack()
    {

        if (isD) return;

        if(HP <= 0)
        {

            controller.controllAble = false;
            animator.SetDieTrigger();
            isD = true;

        }

    }

    public void DIEEVT()
    {

        PlayerPrefs.SetInt("RP", int.MaxValue);
        SceneManager.LoadScene("Lobby");

    }

}
