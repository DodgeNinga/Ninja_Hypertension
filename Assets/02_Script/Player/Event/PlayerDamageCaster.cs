using Class;
using FD.Dev;
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

        float damageValue = itemObj.GetDamageValue(playerHP.GetHPLV);
        hpObj.TakeDamage(damageValue);

        var obj = FAED.Pop("DamageText", hpObj.transform.position +
            new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), Quaternion.identity);

        var damage = obj.GetComponent<DamageText>();
        damage.SetText(damageValue);

    }

}
