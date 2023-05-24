using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceAgent : MonoBehaviour
{
    bool istrace;
    AIBrain _brain;

    private void Awake()
    {
        _brain = GetComponentInParent<AIBrain>();
    }

    public void TraceOn()
    {
        istrace = !istrace;
    }

    private void Update()
    {
        if(istrace)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                                                     _brain.Player.transform.position,
                                                     _brain.enemyData.speed * Time.deltaTime);
        }
    }
}
