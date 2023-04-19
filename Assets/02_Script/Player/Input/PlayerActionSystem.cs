using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionSystem : MonoBehaviour
{

    public event Action<float> OnHorizontalEvnet;
    public event Action<float> OnVerticalEvnet;
    public event Action<float> OnHorizontalEventRaw;
    public event Action OnJumpKeyEvent;
    public event Action OnSkillKeyPressEvent;
    //여기에 키 인풋코드 추가

    public void OnHorizontalExecute(float v) => OnHorizontalEvnet?.Invoke(v);
    public void OnVerticalExecute(float v) => OnVerticalEvnet?.Invoke(v);
    public void OnHorizontalRawExecute(float v) => OnHorizontalEventRaw?.Invoke(v);
    public void OnJumpKeyExecute() => OnJumpKeyEvent?.Invoke();
    public void OnSkillKeyPress() => OnSkillKeyPressEvent?.Invoke();

}
