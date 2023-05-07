using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeEventTransition : AITransition
{
    
    public bool animeValue { get; set; }

    public override bool MakeTransition()
    {

        bool value = animeValue;

        animeValue = animeValue ? false : false;

        return value;

    }
}
