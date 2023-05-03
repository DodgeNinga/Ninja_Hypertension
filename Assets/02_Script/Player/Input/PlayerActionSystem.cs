using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionSystem : MonoBehaviour
{

    public event Action<float> OnHorizontalEvent;
    public event Action<float> OnVerticalEvnet;
    public event Action<float> OnHorizontalRawEvent;
    public event Action OnJumpKeyDownEvent;
    public event Action OnSkillKeyPressEvent;
    public event Action OnSkillKeyUpEvent;
    public event Action OnHoldSkillPressEvnet;
    public event Action OnHoldSkillKeyUpEvent;
    public event Action OnDashKeyPressEvent;
    //여기에 키 인풋코드 추가

    public void OnHorizontalExecute(float v) => OnHorizontalEvent?.Invoke(v);
    public void OnVerticalExecute(float v) => OnVerticalEvnet?.Invoke(v);
    public void OnHorizontalRawExecute(float v) => OnHorizontalRawEvent?.Invoke(v);
    public void OnJumpKeyExecute() => OnJumpKeyDownEvent?.Invoke();
    public void OnSkillKeyPressExecute() => OnSkillKeyPressEvent?.Invoke();
    public void OnSkillKeyUpExecute() => OnSkillKeyUpEvent?.Invoke();
    public void OnHoldSkillPressExecute() => OnHoldSkillPressEvnet?.Invoke();
    public void OnHoldSkillUpExecute() => OnHoldSkillKeyUpEvent?.Invoke();
    public void OnDashKeyPressEventExecute() => OnDashKeyPressEvent?.Invoke();

}
