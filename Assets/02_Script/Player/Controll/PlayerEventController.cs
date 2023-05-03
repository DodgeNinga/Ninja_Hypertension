using Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventController : MonoBehaviour
{
    
    private List<IEventObject> events = new List<IEventObject>();

    private void Awake()
    {
        
        GetComponents(events);

    }

    public void SetAllEvent()
    {

        foreach(var item in events)
        {

            item.AddEvent();

        }

    }

    public void UnSetAllEvent()
    {

        foreach (var item in events)
        {

            item.RemoveEvent();

        }

    }

}
