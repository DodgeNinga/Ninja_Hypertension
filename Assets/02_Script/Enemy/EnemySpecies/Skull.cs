using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    Animator anime;
    ChaseRange ChaseRange;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        ChaseRange = GetComponentInChildren<ChaseRange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ChaseRange.onChaseRange)
        {
            anime.SetBool("fire", true);
        }
        else
        {
            anime.SetBool("fire", false);
        }
    }
}
