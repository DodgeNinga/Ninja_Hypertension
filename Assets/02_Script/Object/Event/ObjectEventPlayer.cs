using Class;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEventPlayer : MonoBehaviour
{

    [SerializeField] private List<PlayEventClass> events = new List<PlayEventClass>();

    public void PlayEvent(string eventName)
    {

        var evtObj = events.Find(x => x.key == eventName);

        if(evtObj != null) 
        {

            evtObj.playEvent?.Invoke();
        
        }

    }

}
