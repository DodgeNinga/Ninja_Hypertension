using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;

public class MageAtkEffect : MonoBehaviour
{
    GameObject Player; // �÷��̾� HP ���� ã��
    public float damage;

    private void Start()
    {
        CalAttack();
    }

    public void CalAttack()
    {
        Player = GameObject.Find("Player"); // HP ������ ������Ʈ
        if(Vector3.Distance(Player.transform.position/*������ ������Ʈ*/, this.transform.position) < 1)
        {
            Debug.Log(10); // ����.������
        }
    }

    public void DieEffect()
    {
        FAED.Push(this.gameObject);
    }
}
