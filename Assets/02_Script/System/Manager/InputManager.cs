using Enums;
using Struct;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField, Header("___Key___")] private List<KeyEvent> keyEvents = new List<KeyEvent>();
    [SerializeField, Header("___Axis___")] private List<AxisEvent> axisEvents = new List<AxisEvent>();
    [SerializeField, Header("___MultKey___")] private List<MultKeyEvnet> multKeyEvnets = new List<MultKeyEvnet>();

    private void Update()
    {

        MultKeyEvnet();
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
                    else if (evt.getAxisType == GetAxisType.Default)
                    {

                        evt.actionEvent?.Invoke(Input.GetAxis("Horizontal"));

                    }
                    else
                    {

                        evt.actionEvent?.Invoke(Input.GetAxisRaw("Horizontal") + Input.GetAxis("Horizontal"));

                    }

                }
                ,

                AxisEventType.Vertical => () =>
                {

                    if (evt.getAxisType == GetAxisType.Raw)
                    {

                        evt.actionEvent?.Invoke(Input.GetAxisRaw("Vertical"));

                    }
                    else if(evt.getAxisType == GetAxisType.Default)
                    {

                        evt.actionEvent?.Invoke(Input.GetAxis("Vertical"));

                    }
                    else
                    {

                        evt.actionEvent?.Invoke(Input.GetAxisRaw("Vertical") + Input.GetAxis("Vertical"));

                    }

                }
                ,
                _ => null

            };

            action?.Invoke();

        }

    }
    
    private void MultKeyEvnet()
    {

        foreach(var item in multKeyEvnets)
        {

            bool value =
                (Input.GetKey(item.firstkeys) && Input.GetKeyDown(item.secoundKey)) ||
                (Input.GetKeyDown(item.firstkeys) && Input.GetKey(item.secoundKey)) ||
                (Input.GetKeyDown(item.firstkeys) && Input.GetKeyDown(item.secoundKey));

            if (value)
            {

                Debug.Log(123);
                item.actionEvent?.Invoke();

            }

        }

    }

}
