using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class TPSENCER : ColSencer
{

    [SerializeField] private Vector2 pos;

    private Transform pl;

    private void Awake()
    {

        pl = FindObjectOfType<PlayerMove>().transform;

    }

    private void Update()
    {

        Sencing();

    }

    public override bool Sencing()
    {

        if (able)
        {

            able = false;
            pl.position = pos;

        }

        return true;

    }

}
