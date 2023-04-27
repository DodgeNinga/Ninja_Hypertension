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

    public void ZoomIn(float zoomInValue, float duration, float spd)
    {

        if (isZoomIn) return;

        isZoomIn = true;
        StartCoroutine(ZoomInCo(zoomInValue, duration, spd));

    }

    private IEnumerator ZoomInCo(float zoomInValue, float duration, float spd)
    {

        float percent = 0;

        while (percent < duration)
        {

            percent += Time.deltaTime;

            cvcam.m_Lens.FarClipPlane = Mathf.Lerp(cvcam.m_Lens.FarClipPlane, 
                zoomInValue, spd * Time.deltaTime);
            yield return null;

        }

        yield return new WaitForSeconds(duration);

        percent = 0;

        while (percent < duration)
        {

            percent += Time.deltaTime;

            cvcam.m_Lens.FarClipPlane = Mathf.Lerp(cvcam.m_Lens.FarClipPlane,
                90, spd * Time.deltaTime);
            yield return null;

        }

        isZoomIn = false;

    }

}
