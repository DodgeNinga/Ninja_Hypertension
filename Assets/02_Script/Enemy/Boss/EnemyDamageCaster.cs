using Class;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageCaster : MonoBehaviour
{

    [SerializeField] private List<DamageCasterClass> castings = new List<DamageCasterClass>();

    public void CastingDamage(HPObject obj, string key)
    {

        var castingObj = castings.Find(x => x.eventKey == key);

        if (castingObj != null) 
        {

            float value = castingObj.GetDamageValue();
            obj.TakeDamage(value);

            var popUp = FAED.Pop("DamageText", obj.transform.position, Quaternion.identity).GetComponent<DamageText>();
            popUp.SetText(value);

        }

    }

}
