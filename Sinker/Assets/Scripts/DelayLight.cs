using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayLight : MonoBehaviour
{
    public Light Light;

    private float Timer;
    private float TargetIntensity;
    private bool Disabled;

    private void Start()
    {
        TargetIntensity = Light.intensity;
        Light.intensity = 0;
        Timer = 10;
    }

    private void Update()
    {
        Timer -= Time.deltaTime;
        if (!Disabled)
        {
            if (Timer < -10)
            {
                Light.intensity = TargetIntensity;
                Disabled = true;
            }
            else if (Timer < 0)
            {
                TurnOn();
            }
        }
    }

    private void TurnOn()
    {
        Light.intensity = Mathf.Lerp(Light.intensity, TargetIntensity, Time.deltaTime);
    }
}
