using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hound : MonoBehaviour
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
            anime.SetBool("run", true);
        }
        else
        {
            anime.SetBool("run", false);
        }
    }
}
