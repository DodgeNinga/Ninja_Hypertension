using Class;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageCaster : MonoBehaviour
{

    [SerializeField] private List<DamageCasterClass> castingList = new List<DamageCasterClass>();

    private PlayerHP playerHP;

    private void Awake()
    {
        
        playerHP = GetComponent<PlayerHP>();

    }

    public void CastingDamage(HPObject hpObj, string key)
    {

        var itemObj = castingList.Find(x => x.eventKey == key);

        if (itemObj == null) return;

        hpObj.TakeDamage(itemObj.GetDamageValue(playerHP.GetHPLV));

    }

}
