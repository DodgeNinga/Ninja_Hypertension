using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObject : InteractionObject
{

    [field:SerializeField] public bool isActive { get; private set; }
    [SerializeField] public string mapName;

    private void Awake()
    {

        interactionText = $"QŰ�� ���� {mapName}���� �̵�";

    }

    private void Update()
    {


        gameObject.layer = isActive ? 7 : changeLayer;

    }

}
