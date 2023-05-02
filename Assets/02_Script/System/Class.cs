using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Class
{

    [System.Serializable]
    public class HitRangeClass
    {

        public string atkKey;
        public string feedBackName = "Hit";
        public bool visible;
        public Color gizmoColor;
        public Vector2 range;
        public Vector2 offSet;
        public UnityEvent<HPObject, string> hitEvt;

    }

    [System.Serializable]
    public class StoryEvnetClass
    {

        public List<StorySencer> storySencers;
        public UnityEvent ableEvent;

    }

    [System.Serializable]
    public class StoryTextClass
    {

        public string humanName;
        [TextArea] public string storyText;
        public float textDuration;
        public UnityEvent apertureEvent;
        public UnityEvent endEvent;

    }

    [System.Serializable]
    public class StoryTextBaseClass
    {

        public string storyName;
        public UnityEvent startEvent;
        public UnityEvent endEvent;
        public List<StoryTextClass> storyTexts;

    }

    [System.Serializable]
    public class CameraTakeClass
    {

        public string takeName;
        public Vector2 cameraTakePos;
        public float duration;
        public UnityEvent takeStartEvent;
        public UnityEvent takeEndEvent;

    }

    [System.Serializable]
    public class DamageCasterClass
    {

        public string eventKey;
        public float damage;
        public float randomValue;
        public float GetDamageValue(float hpLV)
        {

            return Random.Range(damage - randomValue, damage + randomValue) + ((damage * hpLV));

        } 

    }

}
