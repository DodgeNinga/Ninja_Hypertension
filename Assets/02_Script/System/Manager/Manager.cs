using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager
{

    private static Manager instence;

    public static TimeManager timeManagerIns;

    public static TimeManager TimeManagerIns { get { Init(); return timeManagerIns; } }

    public static void Init()
    {

        if(instence == null)
        {

            instence = new Manager();
            timeManagerIns = new TimeManager();

        }

    }

}
