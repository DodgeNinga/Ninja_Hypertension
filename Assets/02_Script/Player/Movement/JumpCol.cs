using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCol : MonoBehaviour
{

    [SerializeField] private List<string> noGroundTag;
    public bool isGround { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        bool isNoGround = false;

        foreach(var item in noGroundTag)
        {

            if (collision.transform.CompareTag(item))
            {

                isNoGround = true; break;

            }

        }

        if(!isNoGround) 
        {
            
            isGround = true;

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        bool isNoGround = false;

        foreach (var item in noGroundTag)
        {

            if (collision.transform.CompareTag(item))
            {

                isNoGround = true; break;

            }

        }

        if (!isNoGround)
        {

            isGround = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        bool isNoGround = false;

        foreach (var item in noGroundTag)
        {

            if (collision.transform.CompareTag(item))
            {

                isNoGround = true; 
                break;

            }

        }

        if (!isNoGround)
        {

            isGround = false;

        }

    }

}
