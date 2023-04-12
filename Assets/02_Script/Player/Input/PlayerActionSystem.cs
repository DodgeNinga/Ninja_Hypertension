using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionSystem : MonoBehaviour
{

    public event Action<float> OnHorizontalEvnet;
    public event Action<float> OnVerticalEvnet;
    public event Action OnJumpKeyEvent;

    public void OnHorizontalExecute(float v) => OnHorizontalEvnet?.Invoke(v);
    public void OnVerticalExecute(float v) => OnVerticalEvnet?.Invoke(v);
    public void OnJumpKeyExecute() => OnJumpKeyEvent?.Invoke();

}
