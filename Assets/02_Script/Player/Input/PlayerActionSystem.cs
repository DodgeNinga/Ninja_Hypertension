using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionSystem : MonoBehaviour
{

    public event Action<float> OnHorizontalEvent;
    public event Action<float> OnVerticalEvnet;
    public event Action<float> OnHorizontalRawEvent;
    public event Action OnJumpKeyEvent;
    public event Action OnSkillKeyPressEvent;
    public event Action OnSkillKeyUpEvent;
    //여기에 키 인풋코드 추가

    public void OnHorizontalExecute(float v) => OnHorizontalEvent?.Invoke(v);
    public void OnVerticalExecute(float v) => OnVerticalEvnet?.Invoke(v);
    public void OnHorizontalRawExecute(float v) => OnHorizontalRawEvent?.Invoke(v);
    public void OnJumpKeyExecute() => OnJumpKeyEvent?.Invoke();
    public void OnSkillKeyPressExecute() => OnSkillKeyPressEvent?.Invoke();
    public void OnSkillKeyUpExecute() => OnSkillKeyUpEvent?.Invoke();

}
