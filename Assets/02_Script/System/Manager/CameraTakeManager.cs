using Class;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTakeManager : MonoBehaviour
{

    [SerializeField] private List<CameraTakeClass> takes = new List<CameraTakeClass>();

    public void StartTake(string value)
    {

        var take = takes.Find(x => x.takeName == value);

        if (take == null) return;



    }

}
