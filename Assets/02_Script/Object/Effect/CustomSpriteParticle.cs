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

    public void PlayParticle()
    {

        var texture = mainSprite.texture;

        var makeSprite = Sprite.Create(texture,
            new Rect(0, 0, texture.width , texture.height) , Vector2.one / 2, mainSprite.pixelsPerUnit);

        particle.textureSheetAnimation.AddSprite(makeSprite);

        particle.Play();

    }

}
