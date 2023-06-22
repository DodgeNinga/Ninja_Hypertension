using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PotionType
{
    Red,
    Blue,
    Green,
    Purple,
    White
}

[CreateAssetMenu(menuName = "SO/potionData", order = 1)]
public class PotionSO : ScriptableObject
{
    public string potionName;
    public PotionType potionType;
}
