using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MANA : MonoBehaviour
{

    [SerializeField] private GameObject f, s;

    private void Start()
    {
        
        if(PlayerPrefs.GetInt("GC") == int.MaxValue)
        {

            f.SetActive(true);

        }
        else
        {

            f.SetActive(false);

        }


        if (PlayerPrefs.GetInt("RP") == int.MaxValue)
        {

            s.SetActive(true);

        }
        else
        {

            s.SetActive(false);

        }


    }

}
