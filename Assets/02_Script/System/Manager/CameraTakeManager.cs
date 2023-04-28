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

        Vector3 vec = take.cameraTakePos;
        vec.z = -10;

        CameraManager.instance.cvcam.transform.DOMove(vec, take.duration)
            .OnComplete(() => take.takeEndEvent?.Invoke());

    }

    public void EndTake()
    {

        CameraManager.instance.SetTarget(true);

    }

}
