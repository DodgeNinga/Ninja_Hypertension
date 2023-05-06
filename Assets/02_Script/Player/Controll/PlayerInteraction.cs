using FD.Program.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : PlayerBehaviorRoot
{

    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private TMP_Text interactionText;
    [SerializeField] private Vector2 interactionRange, interactionOffset;
    [SerializeField] private Color gizmoColor = Color.black;

    private bool interactionAble;

    private void Update()
    {

        var obj = Physics2D.OverlapBox(transform.position + (Vector3)interactionRange, interactionOffset, 0, interactionLayer);

        interactionAble = obj != null;

        if(interactionAble) 
        {

            interactionText.text = "EŰ�� ���� ��ȣ�ۿ�";

        }
        else
        {

            interactionText.text = "";

        }

    }

    public void Interaction()
    {

        if(interactionAble) 
        {

            var obj = Physics2D.OverlapBox(transform.position + (Vector3)interactionRange, interactionOffset, 0, interactionLayer);

            var cpnt = obj.GetComponent<InteractionObject>();

            cpnt.interactionEvent?.Invoke();
            cpnt.gameObject.layer = cpnt.changeLayer;

        }

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        
        var old = Gizmos.color;
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(transform.position + (Vector3)interactionOffset, interactionRange);
        Gizmos.color = old;

    }

    public override void AddEvent()
    {



    }

    public override void RemoveEvent()
    {



    }

#endif

}