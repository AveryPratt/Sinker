using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager _instance;
    public static TimeManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<TimeManager>();
            }
            return _instance;
        }
    }

    public float TargetTimeScale = 1;

    private void Start()
    {
        TargetTimeScale = 1;
    }

    private void Update()
    {
        if (TargetTimeScale < Time.timeScale)
        {
            float newScale = Time.timeScale - Time.unscaledDeltaTime;
            Time.timeScale = newScale >= 0 ? newScale : 0;
        }
        if (TargetTimeScale > Time.timeScale)
        {
            Time.timeScale = TargetTimeScale;
        }
        Time.fixedDeltaTime = Time.timeScale / 60;
    }
}
