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

    protected override void Awake()
    {

        base.Awake();
        AddEvent();

    }

    private void Update()
    {

        var obj = Physics2D.OverlapBox(transform.position + (Vector3)interactionOffset, interactionRange, 0, interactionLayer);

        interactionAble = obj != null;

        if(interactionAble) 
        {

            interactionText.text = obj.GetComponent<InteractionObject>().interactionText;

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

            var obj = Physics2D.OverlapBox(transform.position + (Vector3)interactionOffset, interactionRange, 0, interactionLayer);

            var cpnt = obj.GetComponent<InteractionObject>();

            cpnt.interactionEvent?.Invoke();
            cpnt.gameObject.layer = cpnt.changeLayer;

        }

    }

    public override void AddEvent()
    {

        actionSystem.OnInteractionKeyPressEvent += Interaction;

    }

    public override void RemoveEvent()
    {

        actionSystem.OnInteractionKeyPressEvent -= Interaction;

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        
        var old = Gizmos.color;
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(transform.position + (Vector3)interactionOffset, interactionRange);
        Gizmos.color = old;

    }

#endif

}
