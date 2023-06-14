using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssesinAtk : AttackAgent
{
    Vector3 pos;
    [SerializeField] private GameObject EffectPrefab;
    public override void AttackStart(float atkVal, float atkCool)
    {
        base.AttackStart(atkVal, atkCool);
    }

    public override void OnAttackStart()
    {
        pos = new Vector3(Player.transform.position.x, 0, 0);
        GameObject effect = Instantiate(EffectPrefab);
        effect.transform.position = pos;
        AssasinAtkEffect aae = effect.GetComponent<AssasinAtkEffect>();
        aae.damage = atkv;
        aae.CalAttack();

        effect.transform.position = pos;
        base.OnAttackStart();
    }
}
