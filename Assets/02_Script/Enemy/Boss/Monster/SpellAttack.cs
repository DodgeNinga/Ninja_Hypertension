using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttack : MonoBehaviour
{

    [SerializeField] private Vector2 size, offset;

    public void ChackAttack()
    {

        var obj = Physics2D.OverlapBox(transform.position + (Vector3)offset, size, 0, LayerMask.GetMask("Player"));

        if(obj != null)
        {

            obj.GetComponent<HPObject>().TakeDamage(30);
            obj.GetComponent<FeedBackManager>().PlayFeedback("Hit");

        }

    }

    public void EndAttack()
    {

        FAED.Push(gameObject);

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {

        var old = Gizmos.color;
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position + (Vector3)offset, size);

        Gizmos.color = old;

    }

#endif

}
