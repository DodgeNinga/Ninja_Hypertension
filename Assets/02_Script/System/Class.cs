using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Class
{

    [System.Serializable]
    public class HitRangeStruct
    {

        public string atkKey;
        public string feedBackName = "Hit";
        public bool visible;
        public Color gizmoColor;
        public Vector2 range;
        public Vector2 offSet;
        public UnityEvent<HPObject> hitEvt;

    }

}
