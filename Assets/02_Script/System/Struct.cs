using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Struct
{

    [System.Serializable]
    public struct KeyEvent
    {

        public KeyCode inputKey;
        public KeyEventType eventType;
        public UnityEvent actionEvent;

    }

    [System.Serializable]
    public struct AxisEvent
    {

        public KeyCode inputKey;
        public AxisEventType eventType;
        public GetAxisType getAxisType;
        public UnityEvent<float> actionEvent;

    }

    [System.Serializable]
    public struct MultKeyEvnet
    {

        public List<KeyCode> inputkeys;
        public KeyEventType eventType;
        public UnityEvent actionEvent;

    }

}