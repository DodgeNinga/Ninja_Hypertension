using Class;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryManager : MonoBehaviour
{

    [SerializeField] private UnityEvent startEvent;
    [SerializeField] private List<StoryEvnetClass> storyEvents;

    private void Start()
    {
        
        startEvent?.Invoke();

    }

    private void Update()
    {
        
        foreach(var story in storyEvents) 
        { 
            
            foreach(var evt in story.storySencers)
            {

                if(evt.Sencing()) 
                { 
                    
                    story.ableEvent?.Invoke();

                }

            }

        }

    }

}
