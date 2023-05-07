using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CutSceneEvent : MonoBehaviour
{

    [SerializeField] private UnityEvent cutSceneStartEvent;
    [SerializeField] private UnityEvent cutSceneEndEvent;
    [SerializeField] private UnityEvent<CutSceneEvent> settingCutSceneEvent;

    public void StartCutScene()
    {

        settingCutSceneEvent?.Invoke(this);
        cutSceneStartEvent?.Invoke();

    }

    public void EndCutScene()
    {

        cutSceneEndEvent?.Invoke();

    }

}
