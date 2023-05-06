using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    public Rigidbody2D enemyRigid { get; private set; }

    private void Awake()
    {
        
        enemyRigid = GetComponent<Rigidbody2D>();

    }

}
