using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSpriteParticle : MonoBehaviour
{

    [SerializeField] private Sprite mainSprite;

    private ParticleSystem particle;

    private void Awake()
    {
        
        particle = GetComponent<ParticleSystem>();

    }

}
