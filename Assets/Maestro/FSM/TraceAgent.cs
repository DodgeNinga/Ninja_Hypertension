using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceAgent : MonoBehaviour
{
    Vector3 direction;
    SpriteRenderer _sr;
    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void TraceOn(Transform detectPos, float speed)
    {
        direction = (detectPos.position - transform.position).normalized;
        Vector3 moveDir = direction * speed * Time.deltaTime;
        transform.position += new Vector3(moveDir.x, 0, 0);
    }

    public void FlipFunc()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(angle > -90f && angle < 90)
        {
            _sr.flipX = true;
        }
        else
        {
            _sr.flipX = false;
        }
    }
}
