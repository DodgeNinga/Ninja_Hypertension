using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CutSceneEvent : MonoBehaviour
{

    [SerializeField] private UnityEvent cutSceneStartEvent;
    [SerializeField] private UnityEvent cutSceneEndEvent;

    public void StartCutScene()
    {

        cutSceneStartEvent?.Invoke();

    }

    public void EndCutScene()
    {

        cutSceneEndEvent?.Invoke();

    }

}
