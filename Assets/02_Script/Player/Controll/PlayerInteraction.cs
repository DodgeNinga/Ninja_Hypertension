using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private TMP_Text interactionText;
    [SerializeField] private Vector2 interactionRange, interactionOffset;

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        


    }

#endif

}
