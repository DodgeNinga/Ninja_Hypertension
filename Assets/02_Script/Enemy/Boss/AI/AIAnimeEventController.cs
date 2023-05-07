using Class;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimeEventController : MonoBehaviour
{

    [SerializeField] private List<AIAnimeEventClass> events = new List<AIAnimeEventClass>();
    
    public void SetEvent(string value)
    {

        var cls = events.Find(x => x.key == value);

        cls.evt?.Invoke();

    }

}
