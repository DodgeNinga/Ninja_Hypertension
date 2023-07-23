using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonsterHP : HPObject
{

    [SerializeField] private Slider slider;
    [SerializeField] private float maxHP;
    private MonsterAnimator animator;
    private AIController controller;
    private bool isD;

    private void Awake()
    {

        animator = GetComponent<MonsterAnimator>();
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

        if (HP <= 0)
        {

            controller.controllAble = false;
            animator.SetDieTrigger();
            isD = true;

        }

    }

    public void DIEEVT()
    {

        SceneManager.LoadScene("Lobby");

    }

}
