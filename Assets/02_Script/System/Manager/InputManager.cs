using Enums;
using Struct;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InputManager : MonoBehaviour
{

    [SerializeField, Header("___Key___")] private List<KeyEvent> keyEvents = new List<KeyEvent>();
    [SerializeField, Header("___Axis___")] private List<AxisEvent> axisEvents = new List<AxisEvent>();

    private void Update()
    {

        KeyEvent();
        AxisEvent();

    }

    private void KeyEvent()
    {

        foreach(var evt in keyEvents)
        {

            Action action = evt.eventType switch
            {

                KeyEventType.Up => () =>
                {

                    if (Input.GetKeyUp(evt.inputKey)) evt.actionEvent?.Invoke();

                }
                ,
                KeyEventType.Down => () =>
                {

                    if (Input.GetKeyDown(evt.inputKey)) evt.actionEvent?.Invoke();

                }
                ,
                KeyEventType.Alway => () =>
                {

                    if (Input.GetKey(evt.inputKey)) evt.actionEvent?.Invoke();

                }
                ,
                _ => null

            };

            action?.Invoke();

        }

    }

    private void AxisEvent() 
    {

        foreach (var evt in axisEvents)
        {

            Action action = evt.eventType switch
            {

                AxisEventType.Horizontal => () =>
                {

                    if(evt.getAxisType == GetAxisType.Raw)
                    {

                        evt.actionEvent?.Invoke(Input.GetAxisRaw("Horizontal"));

                    }
                    else
                    {

                        evt.actionEvent?.Invoke(Input.GetAxis("Horizontal"));

                    }

                },

                AxisEventType.Vertical => () =>
                {

                    if (evt.getAxisType == GetAxisType.Raw)
                    {

                        evt.actionEvent?.Invoke(Input.GetAxisRaw("Vertical"));

                    }
                    else
                    {

                        evt.actionEvent?.Invoke(Input.GetAxis("Vertical"));

                    }

                },
                _ => null

            };

            action?.Invoke();

        }

    }

}
