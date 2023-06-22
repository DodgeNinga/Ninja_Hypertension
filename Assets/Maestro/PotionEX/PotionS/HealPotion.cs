using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : PotionBase
{
    [SerializeField] private int _healAmount;
    protected override void PotionEffect()
    {
        _pHp.HealingHP(_healAmount);
    }
}
