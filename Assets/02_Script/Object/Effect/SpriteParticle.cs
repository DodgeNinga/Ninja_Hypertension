using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteParticle : MonoBehaviour
{

    private ParticleSystem particle;

    private void Awake()
    {
        
        particle = GetComponent<ParticleSystem>();

    }

    public void MakeParticle(Sprite sprite)
    {

        var texture = sprite.texture;

        var makeSprite = Sprite.Create(texture,
            new Rect(0, 
            0, texture.width / Random.Range(2, 4), texture.height / Random.Range(2, 4)),
            Vector2.one / 2, sprite.pixelsPerUnit);

        particle.textureSheetAnimation.AddSprite(makeSprite);

        particle.Play();

    }

}
