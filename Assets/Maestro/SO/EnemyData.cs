using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemyData", order = 0)]
public class EnemyData : ScriptableObject
{
    public float speed;
    public float atkValue;
    public float detectRange;
    public float atkRange;
    public float atkcool;
}
