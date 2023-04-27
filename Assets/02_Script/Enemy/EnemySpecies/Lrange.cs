using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lrange : MonoBehaviour
{
    public GameObject bulletPrefabs;
    ChaseRange ChaseRange;
    public float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        ChaseRange = GetComponentInChildren<ChaseRange>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Fire()
    {
        while (true)
        {
            if (ChaseRange.onChaseRange)
            {
                Instantiate(bulletPrefabs,transform.position,Quaternion.identity);
                yield return new WaitForSeconds(delayTime);
            }
            yield return null;
        }
    }
}
