using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingPotion : PotionBase
{
    [SerializeField] int damageAmount;
    PlayerHP playerHP;
    private void Awake()
    {
        playerHP = FindObjectOfType<PlayerHP>();
    }
    public override void PotionEvent()
    {
        playerHP.TakeDamage(damageAmount);
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
