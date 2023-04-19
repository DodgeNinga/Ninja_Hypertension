using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargedSencer : SencerRoot
{

    [SerializeField] private SencerRoot[] leftSencer;
    [SerializeField] private SencerRoot[] rightSencer;

    public bool LeftSencer => ChackSencer(leftSencer);
    public bool RightSencer => ChackSencer(rightSencer);

    private bool ChackSencer(SencerRoot[] sencers)
    {

        bool value = false;

        foreach(var item in sencers) 
        {

            if (item.sencerValue == false)
            {

               value = false; 
               break;

            }
            value = true;

        }

        return value;

    }

}
