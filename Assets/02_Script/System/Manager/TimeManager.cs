using FD.Dev;
using UnityEngine;

public class TimeManager
{

    private bool isSetTime = false;

    public void SetTimeScale(float value, float duration)
    {

        if (isSetTime) return;

        isSetTime = true;
        Time.timeScale = value;

        FAED.InvokeDelayReal(() =>
        {

            isSetTime = false;
            Time.timeScale = 1;

        }, duration);

    }

}
