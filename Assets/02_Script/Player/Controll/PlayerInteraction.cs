using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
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

            interactionText.text = "E키를 눌러 상호작용";

        }

    }

    public void Interaction()
    {

        if(interactionAble) 
        {

            var obj = Physics2D.OverlapBox(transform.position + (Vector3)interactionRange, interactionOffset, 0, interactionLayer);


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

#endif

}
