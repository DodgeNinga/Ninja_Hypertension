using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;

public class AssasinAtkEffect : MonoBehaviour
{
    GameObject Player;
    public float damage;

    
    public void CalAttack()
    {
        Player = GameObject.Find("Player"); // HP 로직의 오브젝트
        if (Vector3.Distance(Player.transform.position/*로직의 오브젝트*/, this.transform.position) < 1)
        {
            Debug.Log(damage); // 로직.데미지
        }
    }

    public void DieEffect()
    {
        FAED.Push(this.gameObject);
    }
}
