using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FD.Dev;
using System;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private Transform target; 
    private CinemachineVirtualCamera cvcam;
    private CinemachineBasicMultiChannelPerlin cbmcp;
    private bool isDurated = false;
    private bool isZoomIn = false;

    public static CameraManager instance;

    private void Awake()
    {
        
        cvcam = FindObjectOfType<CinemachineVirtualCamera>();
        cbmcp = cvcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        instance = this;

    }

    public void Shake(float amplitudeGain, float frequencyGain, float duration, bool isDurated)
    {

        if (isDurated && this.isDurated) return;

        if (isDurated)
        {

            this.isDurated = true;

        }

        cbmcp.m_AmplitudeGain += amplitudeGain;
        cbmcp.m_FrequencyGain += frequencyGain;

        FAED.InvokeDelay(() =>
        {

            cbmcp.m_AmplitudeGain -= amplitudeGain;
            cbmcp.m_FrequencyGain -= frequencyGain;

            if (isDurated)
            {

                this.isDurated = false;

            }

        }, duration);

    }

    public void SetTarget(bool able)
    {

        cvcam.Follow = able ? target : null;

    }

}
