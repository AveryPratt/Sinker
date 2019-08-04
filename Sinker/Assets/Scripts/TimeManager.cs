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
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0, Time.unscaledDeltaTime);
        }
        if (TargetTimeScale > Time.timeScale)
        {
            Time.timeScale = TargetTimeScale;
        }
        Time.fixedDeltaTime = Time.timeScale / 60;

        if (Input.GetKey(KeyCode.Space))
        {
            TargetTimeScale = 1;
            TrackingCamera.Instance.CheckpointHit = false;
        }
    }
}
