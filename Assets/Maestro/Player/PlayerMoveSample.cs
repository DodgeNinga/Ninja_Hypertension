using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSample : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }

        if(Input.GetButtonDown("Jump"))
        {
            AIBrain _aiBrain;
            _aiBrain = FindObjectOfType<AIBrain>();
            _aiBrain.HPDamage(10);
        }
    }
}
