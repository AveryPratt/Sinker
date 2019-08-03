using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLight : MonoBehaviour
{
    public Light Light;

    private float TargetIntensity;

    private void Start()
    {
        TargetIntensity = Light.intensity;
    }

    public void Extinguish()
    {
        TargetIntensity = 0;
    }

    private void Update()
    {
        Light.intensity = Mathf.Lerp(Light.intensity, TargetIntensity, Time.deltaTime);
    }
}
