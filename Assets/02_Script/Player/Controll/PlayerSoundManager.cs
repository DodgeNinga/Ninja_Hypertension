using Class;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSoundManager : PlayerRoot
{

    [SerializeField] private List<SoundEventClass> soundEvents = new List<SoundEventClass>();

    private float fallingTime;

    private void Update()
    {

        FallingChack();
        PlayLandingSound();

    }

    private void FallingChack()
    {

        if (!jumpCol.isGround)
        {

            fallingTime += Time.deltaTime;

        }

    }

    private void PlayLandingSound()
    {

        if(fallingTime > 1 && jumpCol.isGround) 
        {

            PlaySound("Landing");
        
        }

    }

    public void PlayAttackSound()
    {

        PlaySound("Attack");

    }

    public void PlayJumpSound()
    {

        if (jumpCol.isGround) return;
        
        PlaySound("JumpSound");

    }

    public void PlaySound(string key)
    {

        var obj = soundEvents.Find(x => x.key == key);

        if(obj != null) 
        { 
            
            obj.soundSource.Play();
        
        }

    }

}
