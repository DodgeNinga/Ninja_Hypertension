using Class;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{

    [SerializeField] private List<SoundEventClass> soundEvents = new List<SoundEventClass>();

    public void PlaySound(string key)
    {

        var obj = soundEvents.Find(x => x.key == key);

        if(obj != null) 
        { 
            
            obj.soundSource.Play();
        
        }

    }

}
