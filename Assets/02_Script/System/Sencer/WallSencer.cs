using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSencer : SencerRoot
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        sencerValue = true;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        sencerValue = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        sencerValue = false;

    }

}
