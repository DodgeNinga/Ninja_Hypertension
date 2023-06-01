using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;

public class MageAtkEffect : MonoBehaviour
{
    GameObject Player; // 플레이어 HP 로직 찾기
    public float damage;

    private void Start()
    {
        CalAttack();
    }

    public void CalAttack()
    {
        Player = GameObject.Find("Player"); // HP 로직의 오브젝트
        if(Vector3.Distance(Player.transform.position/*로직의 오브젝트*/, this.transform.position) < 1)
        {
            Debug.Log(10); // 로직.데미지
        }
    }

    public void DieEffect()
    {
        FAED.Push(this.gameObject);
    }
}
