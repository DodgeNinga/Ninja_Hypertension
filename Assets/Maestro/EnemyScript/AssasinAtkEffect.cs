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
        Player = GameObject.Find("Player"); // HP ������ ������Ʈ
        if (Vector3.Distance(Player.transform.position/*������ ������Ʈ*/, this.transform.position) < 1)
        {
            Debug.Log(damage); // ����.������
        }
    }

    public void DieEffect()
    {
        FAED.Push(this.gameObject);
    }
}
