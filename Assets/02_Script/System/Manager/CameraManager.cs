using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FD.Dev;

public class CameraManager : MonoBehaviour
{

    private CinemachineVirtualCamera cvcam;
    private CinemachineBasicMultiChannelPerlin cbmcp;
    private bool isDurated = false;

    private void Awake()
    {
        
        cvcam = FindObjectOfType<CinemachineVirtualCamera>();
        cbmcp = cvcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }

    public void Shake(float amplitudeGain, float frequencyGain, float duration, bool isDurated)
    {

        if (isDurated && !this.isDurated) return;

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

}
