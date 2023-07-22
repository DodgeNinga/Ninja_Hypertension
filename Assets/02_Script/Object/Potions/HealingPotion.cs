using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : PotionBase
{
    [SerializeField] int healAmount;
    PlayerHP playerHP;
    private void Awake()
    {
        playerHP = FindObjectOfType<PlayerHP>();
    }
    public override void PotionEvent()
    {
        playerHP.HealingHP(healAmount);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PotionEvent();
            Destroy(gameObject);
        }
    }
}
