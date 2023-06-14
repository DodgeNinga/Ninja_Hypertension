using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAtk : AttackAgent
{
    [SerializeField] private GameObject EffectPrefab;

    public override void AttackStart(float atkVal, float atkCool)
    {
        base.AttackStart(atkVal, atkCool);
    }

    public override void OnAttackStart()
    {
        Vector3 pos = new Vector3(Player.transform.position.x, 0, 0);
        GameObject effect = Instantiate(EffectPrefab);
        effect.transform.position = pos;
    }
}
