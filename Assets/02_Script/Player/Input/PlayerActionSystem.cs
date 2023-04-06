using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionSystem : MonoBehaviour
{

    public event Action<float> OnHorizontalEvnet;
    public event Action<float> OnVerticalEvnet;
    public event Action jumpKeyEvent;

}
