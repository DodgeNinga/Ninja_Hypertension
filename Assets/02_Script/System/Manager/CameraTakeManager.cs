using Class;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraTakeManager : MonoBehaviour
{

    [SerializeField] private List<CameraTakeClass> takes = new List<CameraTakeClass>();

    public void StartTake(string value)
    {

        var take = takes.Find(x => x.takeName == value);

        if (take == null) return;

        take.takeStartEvent?.Invoke();
        CameraManager.instance.SetTarget(false);

        CameraManager.instance.cvcam.transform.DOMove(take.cameraTakePos, take.duration)
            .OnComplete(() => take.takeEndEvent?.Invoke());

    }

    public void EndTake()
    {

        CameraManager.instance.SetTarget(true);

    }

}
