using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{

    [SerializeField] private string particleKey;

    private ParticleSystem particle;

    public void StartPlay(Vector3 pos, Quaternion rot, float xScale, Transform parent = null)
    {

        particle = FAED.Pop(particleKey, pos, rot).GetComponent<ParticleSystem>();
        particle.Play();
        particle.transform.localScale = new Vector2(xScale, 1);

        particle.transform.SetParent(parent);

    }

    public void EndPlay()
    {

        particle.Stop();
        FAED.Push(particle.gameObject);

    }

}
