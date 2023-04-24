using FD.Dev;
using UnityEngine;

public class TimeManager
{

    private bool isSetTime = false;

    public void SetTimeScale(float value, float duration)
    {

        if (isSetTime) return;

        Time.timeScale = value;
        FAED.InvokeDelayReal(() =>
        {

            isSetTime = true;
            Time.timeScale = 1;

        }, duration);

    }

}
