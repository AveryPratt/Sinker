using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    private void OnEnable()
    {
        if (TrackingCamera.Instance)
        {
            TrackingCamera.Instance.Targets.Add(gameObject);
        }
    }

    private void OnDisable()
    {
        if (TrackingCamera.Instance)
        {
            TrackingCamera.Instance.Targets.Remove(gameObject);
        }
    }
}
